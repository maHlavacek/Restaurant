using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core
{
    public class Article
    {
        public Article(string item,double price,double timeToBuild)
        {
            Item = item;
            Price = price;
            TimeToBuild = timeToBuild;
        }

        public string Item { get; set; }
        public double Price { get; set; }
        public double TimeToBuild { get; set; }
    }
}
