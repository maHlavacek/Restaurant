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
        private Article _article;
        private DateTime _startToBuild;
        private Guest _guest;
        public event EventHandler<string> LogTask;
        #endregion

        #region Constructor
        public Task(Article article,DateTime time,Guest guest,EventHandler<string> logTask)
        {
            _article = article;
            _startToBuild = time;
            _guest = guest;
            LogTask += logTask;
        }
        #endregion



        #region Methods
        public void OnOrderRecived(object sender,DateTime time)
        {
            if(_startToBuild.AddMinutes(_article.TimeToBuild) == time)
            {
                LogTask?.Invoke(this,$"{_article.Item} für {_guest.Name} wird serviert");
            }
        }
    
        #endregion
    }
}
