using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BNM_API
{
    /// <summary>
    /// Interaction logic for RateInfo.xaml
    /// </summary>
    public partial class RateInfo : Window
    {
        public RateInfo()
        {
            InitializeComponent();
        }

        private async void Load_exchange_rate_Click(object sender, RoutedEventArgs e)
        {
            var rateInfo = await RateProcessor.LoadRates();

            currency_code_text.Text = $"{rateInfo.currency_code}";
            date_text.Text = $"{rateInfo.rate.date}";
            buying_rate_text.Text = $"{rateInfo.rate.buying_rate}";
            selling_rate_text.Text = $"{rateInfo.rate.selling_rate}";
            middle_rate_text.Text = $"{rateInfo.rate.middle_rate}";
        }

    }
}
