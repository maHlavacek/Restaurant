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
         public List<Order> Orders { get; set; }
        #endregion


        #region Methods

     

        public void ReadOrdersFromCsv(string filename)
        {
            Order order = new Order();
            string[] lines = File.ReadAllLines(filename,Encoding.Default);

            for (int i = 1; i < lines.Length; i++)
            {
                string[] rows = lines[i].Split(';');
                order.Delay = int.Parse(rows[0]);
                order.GuestName = rows[1];
                order.OrderType = rows[2];
                order.ArticleName = rows[3];
                Orders.Add(order);
            }
        }
        #endregion


    }


}
