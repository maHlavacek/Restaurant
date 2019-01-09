using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core
{
    public class Order
    {
        public string Article { get; set; }

        public DateTime Delay { get; set; }

        public string GuestName { get; set; }
    }
}
