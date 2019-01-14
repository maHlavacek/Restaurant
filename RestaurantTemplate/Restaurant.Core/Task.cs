using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core
{
    public class Task
    {
        #region Fields
        private Order _order;
        private DateTime _startToBuild;
      //  private readonly Guest _guest;
        public static event EventHandler<string> LogTask;
        #endregion

        #region Constructor
        public Task(Order order,DateTime time/*,Guest guest*/)
        {
            _order = order;
            _startToBuild = time;
            //_guest = guest;
        }
        #endregion



        #region Methods



        public void OnOrderRecived(object sender,DateTime time)
        {
            if (_startToBuild.AddMinutes(_order.Article.TimeToBuild) == time)
            {
                LogTask?.Invoke(this,$"{_order.Article.Item} für {_order.GuestName} wird serviert");
            }
        }
    
        #endregion
    }
}
