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
            FastClock.Instance.Time = DateTime.Parse("12:00:00");
            FastClock.Instance.OneMinuteIsOver += OnOneMinuteIsOver;
            Waiter waiter = Waiter.Instance;
            waiter.OrderRecived += OnOrderRecived;
            FastClock.Instance.IsRunning = true;
            TextBlockLog.Text = "";
        }

        private void OnOneMinuteIsOver(object sender, DateTime time)
        {
            Title = $"RESTAURANTSIMULATOR, UHRZEIT: " + time.ToShortTimeString();
        }

        private void OnOrderRecived(object sender, string massage)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(FastClock.Instance.Time.ToShortTimeString() + "\t");
            stringBuilder.Append(massage + "\n");
            TextBlockLog.Text += stringBuilder.ToString();
        }
    }
}
