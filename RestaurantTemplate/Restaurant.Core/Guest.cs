using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core
{
    public class Guest
    { 
        public Guest(string guestName, string orederedArticle)
        {
            Name = guestName;
        }

        public string Name { get; set; }

        public List<Article> OrderedArticles { get; set; }

        public double Payment { get; set; }
    }
}
