using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core
{
    public class Order
    {
        #region Properties
        public double Delay { get; set; }
        public string GuestName { get; set; }
        public OrderType OrderType { get; set; }
        public Article Article { get; set; }
        #endregion

        #region Constructor

        /// <summary>
        /// Constructor für OrderType ToPay da dies keinen Artikel beinhalten
        /// </summary>
        /// <param name="delay"></param>
        /// <param name="guestName"></param>
        /// <param name="orderType"></param>
        public Order(double delay, string guestName, OrderType orderType)
        {
            Delay = delay;
            GuestName = guestName;
            OrderType = orderType;
        }
        /// <summary>
        /// Constructor für OrderType Order da diese eine Articel beinhalten
        /// </summary>
        /// <param name="delay"></param>
        /// <param name="guestName"></param>
        /// <param name="orderType"></param>
        /// <param name="article"></param>
        public Order(double delay, string guestName, OrderType orderType, Article article) :this (delay,guestName, orderType)
        {
            Article = article;
        }
        #endregion
    }
}
