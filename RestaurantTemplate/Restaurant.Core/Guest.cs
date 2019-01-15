using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core
{
    public class Guest
    { 
        private double _payment;
        public Guest(Order order)
        {
            _orderedArticles = new List<Article>();
            _payment = 0;
            Name = order.GuestName;
            _orderedArticles.Add(order.Article);
        }

        public string Name { get; private set; }


        public List<Article> _orderedArticles;

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
    }
}
