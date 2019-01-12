using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core
{
    public class Order
    {
        public List<Article> Article { get; set; }

        public int Delay { get; set; }

        public string GuestName { get; set; }
        public OrderType OrderType { get; set; }
    }
}
