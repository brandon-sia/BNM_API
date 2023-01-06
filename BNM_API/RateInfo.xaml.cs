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
        internal static string? currency_code { get; set; }
        internal static string? session { get; set; }
        internal static string? exchange_rate_date { get; set; }
        public RateInfo()
        {
            InitializeComponent();
        }

        public async void Load_exchange_rate_Click(object sender, RoutedEventArgs e)
        {

            currency_code = currency_code_comboBox.Text;
            session = session_comboBox.Text;
            exchange_rate_date = exchange_rate_datePicker.SelectedDate.Value.ToString("yyyy-MM-dd");

            try
            {
                var rateInfo = await RateProcessor.LoadRates();

                //date_text.Text = $"{rateInfo.rate.date}";
                buying_rate_text.Text = $"{rateInfo.rate.buying_rate}";
                selling_rate_text.Text = $"{rateInfo.rate.selling_rate}";
                middle_rate_text.Text = $"{rateInfo.rate.middle_rate}";
                unit_text.Text = $"{rateInfo.unit}";

            }
            catch(Exception ex)
            {
                string message = "No data found";
                MessageBox.Show(message);
            }

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
