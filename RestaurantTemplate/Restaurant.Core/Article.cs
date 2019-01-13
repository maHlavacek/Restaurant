using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core
{
    public class Article
    {
        private int timeToBuilt;

        public Article(string orederedArticle)
        {
        }

        public Article(string item, double price, int timeToBuilt)
        {
            Item = item;
            Price = price;
            this.timeToBuilt = timeToBuilt;
        }

        public string Item { get; set; }
        public double Price { get; set; }
        public int TimeToBuild { get; set; }
    }
}
