using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core
{
    public class Guest
    {
        public string Name { get; set; }

        public OrderType Type { get; set; }

        public List<Article> OrderedArticles { get; set; }

        public double Payment { get; set; }
    }
}
