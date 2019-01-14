using Restaurant.Core;
using System;
using System.Text;

namespace Restaurant.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MetroWindow_Initialized(object sender, EventArgs e)
        {
            Waiter waiter = Waiter.Instance;
            waiter.OrderRecived += Waiter_OrderRecived;
           // FastClock.Instance.Time = new DateTime(2019,01,14,12,00,00);
            FastClock.Instance.IsRunning = true;
            TextBlockLog.Text = "";
        }

        private void Waiter_OrderRecived(object sender, string massage)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(FastClock.Instance.Time.ToShortTimeString() + "\t");
            stringBuilder.Append(massage + "\n");
            TextBlockLog.Text += stringBuilder.ToString();
        }
    }
}
