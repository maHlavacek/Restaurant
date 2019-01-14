﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace Restaurant.Core
{
    public class Waiter
    {
        #region Properties
        private List<Guest> Guests { get; set; }
        private List<Order> _listOfOrders;
        private List<Article> _listOfArticles;
        private DateTime _startTime;

        private static Waiter _instance;

        public static Waiter Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new Waiter();
                }
                return _instance;
            }
        }
        #endregion

        #region Event
        public event EventHandler<string> OrderRecived;
        #endregion
        #region Constructor

        private Waiter()
        {
            _listOfOrders = new List<Order>();
            _listOfArticles = new List<Article>();
            ReadArticlesFromCsv("Articles.csv");
            ReadAllOrders("Orders.csv");
            FastClock.Instance.OneMinuteIsOver += OnOneMinuteIsOver;
            _startTime = FastClock.Instance.Time;
        }
        #endregion

        #region Methods

        public string[] ReadLinesFromCsvFile(string filename)
        {
            string path = MyFile.GetFullNameInApplicationTree(filename);
            if (!File.Exists(path))
            {
                return null;
            }
            string[] lines = File.ReadAllLines(path, Encoding.Default);
            return lines;
        }

        /// <summary>
        /// Die Bestellungen werden Eingelesen und demjenigen Gast zugewiesen
        /// </summary>
        /// <param name="filename"></param>
        public void ReadAllOrders(string filename)
        {
            string[] lines = ReadLinesFromCsvFile(filename);
            for (int i = 1; i < lines.Length; i++)
            {
                string[] rows = lines[i].Split(';');

                double delay = double.Parse(rows[0]);
                string guestName = rows[1];

                if (rows[2] == "Order")
                {
                    OrderType orderType = OrderType.Order;
                    string articleName = rows[3];
                    Order order = new Order(delay, guestName, orderType, GetArticle(articleName));
                    _listOfOrders.Add(order);
                }
                else
                {
                    Order order = new Order(delay, guestName, OrderType.ToPay);
                    _listOfOrders.Add(order);
                }
            }
        }      

        /// <summary>
        /// Lest die Artikel von der CSV datai ein und speichert sie
        /// </summary>
        /// <param name="filename"></param>
        public void ReadArticlesFromCsv(string filename)
        {
            string[] lines = ReadLinesFromCsvFile(filename);

            for (int i = 1; i < lines.Length; i++)
            {
                string[] rows = lines[i].Split(';');

                string item = rows[0];
                double price = double.Parse(rows[1]);
                double timeToBuilt = double.Parse(rows[2]);

                Article article = new Article(item, price, timeToBuilt);
                _listOfArticles.Add(article);
            }
        }
        /// <summary>
        /// Gast wird gesucht und zurückgegeben
        /// Wenn er nicht gefunden wird, wird null zurück gegeben
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Guest GetGuest(string name)
        {
            if (name == null)
            {
                return null;
            }
            foreach (Guest guest in Guests)
            {
                if (guest.Name == name)
                {
                    return guest;
                }
            }
            return null;
        }
        /// <summary>
        /// Artikel wird gesucht und zurückgegeben, null wird zurück gegeben wenn dieser Artikel nicht existiert
        /// </summary>
        /// <param name="articleName"></param>
        /// <returns></returns>
        public Article GetArticle(string articleName)
        {
            if (articleName == null)
            {
                return null;
            }
            foreach (Article article in _listOfArticles)
            {
                if (article.Item == articleName)
                {
                    return article;
                }
            }
            return null;
        }

        public void OnOneMinuteIsOver(object sender, DateTime time)
        {
            foreach (Order order in _listOfOrders)
            {
                if (_startTime.AddMinutes(order.Delay) == time)
                {
                    Task task = new Task(order, time, GetGuest(order.GuestName));
                    if (order.OrderType == OrderType.ToPay)
                    {
                        OnOrderRecieved(this, $"{order.GuestName} bezahlt {GetGuest(order.GuestName).Payment}");
                    }
                    else
                    {
                        OnOrderRecieved(this, $"{order.Article.Item} für {order.GuestName} ist bestellt");
                    }
                }

            }
        }

        private void OnOrderRecieved(object sender, string massage)
        {
            OrderRecived?.Invoke(this, massage);
        }
        #endregion
    }
}
