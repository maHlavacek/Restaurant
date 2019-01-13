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
        public Guest(string guestName)
        {
            Name = guestName;
        }

        public string Name { get; set; }

        public List<Article> OrderedArticles { get; set; }

        public double Payment
        {
            get
            {             
                foreach (Article article in OrderedArticles)
                {
                    _payment += article.Price;
                }
                return _payment;
            }

        }
    }
}
