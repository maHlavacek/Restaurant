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
        public static event EventHandler<Order> LogTask;
        #endregion

        #region Constructor
        public Task(Order order)
        {
            _startToBuild = FastClock.Instance.Time.AddMinutes(order.Delay);
            FastClock.Instance.OneMinuteIsOver += Instance_OneMinuteIsOver;
            _order = order;
        }

        #endregion



        #region Methods

        public void Instance_OneMinuteIsOver(object sender,DateTime time)
        {
            if (_startToBuild.AddMinutes(_order.Article.TimeToBuild) == time)
            {
                _order.OrderType = OrderType.Ready;
                LogTask?.Invoke(this, _order);
            }
        }
    
        #endregion
    }
}
