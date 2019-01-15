using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core
{
    public class Guest
    {     
        #region Fields

        public List<Article> _orderedArticles;
        private double _payment;

        public string Name { get; private set; }
        #endregion

        #region Properties
        public double Payment
        {
            get
            {
                foreach (Article article in _orderedArticles)
                {
                    _payment += article.Price;
                }
                return _payment;
            }
        }
        #endregion


        #region Constructor
        public Guest(Order order)
        {
            _orderedArticles = new List<Article>();
            _payment = 0;
            Name = order.GuestName;
            _orderedArticles.Add(order.Article);
        }
        #endregion       
    }
}
