using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core
{
    public class Order
    {
        public Order(int delay, string guestName, OrderType orderType)
        {
            Delay = delay;
            GuestName = guestName;
            OrderType = orderType;
        }
        public Order(int delay, string guestName, OrderType orderType, Article article) :this (delay,guestName, orderType)
        {
            Article = article;
        }

        public int Delay { get; set; }

        public string GuestName { get; set; }

        public OrderType OrderType { get; set; }
       

        public Article Article{ get; set; }
    }
}
