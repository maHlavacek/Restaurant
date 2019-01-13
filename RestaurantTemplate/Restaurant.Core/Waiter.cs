using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core
{
    public class Waiter
    {
        #region Properties
        public List<Guest> Guests { get; set; }
        public List<Order> Orders { get; set; }
        public List<Article> ListOfArticles { get; set; }
        #endregion


        #region Methods

        public void ReadOrdersFromCsv(string filename)
        {
            string[] lines = File.ReadAllLines(filename,Encoding.Default);

            for (int i = 1; i < lines.Length; i++)
            {
                string[] rows = lines[i].Split(';');

                int delay = int.Parse(rows[0]);
                string guestName = rows[1];
                OrderType orderType = new OrderType();
                if(rows[2] == "Order")
                {
                     orderType = OrderType.Order;
                }
                if (rows[2] == "ToPay")
                {
                    orderType = OrderType.ToPay;
                }
                string articleName = rows[3];

                Order order = new Order(delay,guestName,orderType,articleName);
                Orders.Add(order);
            }
        }

        public void ReadArticlesFromCsv(string filename)
        {
            string[] lines = File.ReadAllLines(filename, Encoding.Default);
          //  Article articles = new Article();

            for (int i = 1; i < lines.Length; i++)
            {
                string[] rows = lines[1].Split(';');

                string item = rows[0];
                double price = double.Parse(rows[1]);
                int timeToBuilt = int.Parse(rows[2]);

                Article articles = new Article(item,price,timeToBuilt);
                ListOfArticles.Add(articles);
            }
        }
        #endregion


    }


}
