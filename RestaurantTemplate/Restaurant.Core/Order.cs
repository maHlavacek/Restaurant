using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core
{
    public class Order
    {
        public int Delay { get; set; }

        public string GuestName { get; set; }

        public string OrderType { get; set; }

        public string ArticleName { get; set; }
    }
}
