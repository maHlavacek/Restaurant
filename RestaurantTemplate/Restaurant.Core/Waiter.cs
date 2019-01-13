using System;
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
        public List<Guest> Guests { get; set; }
        public List<Order> ListOfOrders { get; set; }
        public List<Article> ListOfArticles { get; private set; }


        #endregion

        #region Event
        public event EventHandler<string> OrderRecived;
        #endregion
        #region Constructor

        public Waiter()
        {
            ListOfOrders = ReadAllOrders("Orders.csv");
            ListOfArticles = ReadArticlesFromCsv("Articles.csv");
            FastClock.Instance.OneMinuteIsOver += OnOneMinuteIsOver;
            
        }
        #endregion

        #region Methods


        /// <summary>
        /// Die Bestellungen werden Eingelesen und demjenigen Gast zugewiesen
        /// </summary>
        /// <param name="filename"></param>
        public List<Order> ReadAllOrders(string filename)
        {
            List<Order> orders = new List<Order>();
            string[] lines = MyFile.ReadLinesFromCsvFile(filename);
            for (int i = 1; i < lines.Length; i++)
            {
                string[] rows = lines[i].Split(';');

                int delay = int.Parse(rows[0]);
                string guestName = rows[1];

                if (rows[2] == "Order")
                {
                    OrderType orderType = OrderType.Order;
                    string articleName = rows[3];
                    Order order = new Order(delay, guestName, orderType, GetArticle(articleName));
                    orders.Add(order);
                }
                else
                {
                    Order order = new Order(delay, guestName, OrderType.ToPay);
                    orders.Add(order);
                }


            }
            return orders;
        }      

        /// <summary>
        /// Lest die Artikel von der CSV datai ein und speichert sie
        /// </summary>
        /// <param name="filename"></param>
        public List<Article> ReadArticlesFromCsv(string filename)
        {
            List<Article> articles = new List<Article>();
            string[] lines = File.ReadAllLines(filename, Encoding.Default);

            for (int i = 1; i < lines.Length; i++)
            {
                string[] rows = lines[i].Split(';');

                string item = rows[0];
                double price = double.Parse(rows[1]);
                int timeToBuilt = int.Parse(rows[2]);

                Article article = new Article(item, price, timeToBuilt);
                articles.Add(article);
            }
            return articles;
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
            foreach (Article article in ListOfArticles)
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
            foreach (Order order in ListOfOrders)
            {
                if(order.Delay == time.Minute)
                {
                    Task task = new Task(order,time/*,GetGuest(order.GuestName)*/);
                    OrderRecived?.Invoke(this,$"{order.Article} für {order.GuestName} ist bestellt");                 
                }
            }

        }
        #endregion
    }
}
