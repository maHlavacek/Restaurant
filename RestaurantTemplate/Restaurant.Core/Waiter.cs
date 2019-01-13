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
       // public List<Order> ListOfOrders { get; set; }
        public List<Article> ListOfArticles { get; set; }


        #endregion


        #region Methods





        /// <summary>
        /// Die Bestellungen werden Eingelesen und demjenigen Gast zugewiesen
        /// </summary>
        /// <param name="filename"></param>
        public void ReadAllOrders(string filename)
        {
            List<Order> listOfOrder = new List<Order>();
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
                    Order order = new Order(delay, guestName, orderType, articleName);
                    AddOrdersToGuests(order);
                }           
            }         
        }
        /// <summary>
        /// Neuer Gast wird angelegt und dessen Bestellung wird gespeichert
        /// Wenn der Gast schon existiert wird die Bestellung ihm zugewiesen
        /// </summary>
        /// <param name="order"></param>
        public void AddOrdersToGuests(Order order)
        {  
            if (GetGuest(order.GuestName) == null)
            {
                Guest newGuest = new Guest(order.GuestName);
                Guests.Add(newGuest);
            }
            else
            {
                Guest guest = GetGuest(order.GuestName);
                Article newArticle = GetArticle(order.ArticleName);
                guest.OrderedArticles.Add(newArticle);
            }
        }             

        /// <summary>
        /// Lest die Artikel von der CSV datai ein und speichert sie
        /// </summary>
        /// <param name="filename"></param>
        public void ReadArticlesFromCsv(string filename)
        {
            string[] lines = File.ReadAllLines(filename, Encoding.Default);

            for (int i = 1; i < lines.Length; i++)
            {
                string[] rows = lines[i].Split(';');

                string item = rows[0];
                double price = double.Parse(rows[1]);
                int timeToBuilt = int.Parse(rows[2]);

                Article articles = new Article(item, price, timeToBuilt);
                ListOfArticles.Add(articles);
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
            foreach (Article article in ListOfArticles)
            {
                if (article.Item == articleName)
                {
                    return article;
                }
            }
            return null;
        }
        #endregion
    }
}
