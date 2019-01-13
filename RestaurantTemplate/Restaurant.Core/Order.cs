using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core
{
    public class Order
    {

        public Order(int delay, string guestName, OrderType orderType, string articleName)
        {
            Delay = delay;
            GuestName = guestName;
            OrderType = orderType;
            ArticleName = articleName;
        }

        public int Delay { get; set; }

        public string GuestName { get; set; }

        public OrderType OrderType { get; set; }
       

        public string ArticleName { get; set; }
    }
}
