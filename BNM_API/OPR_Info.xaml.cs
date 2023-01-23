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
using static System.Collections.Specialized.BitVector32;

namespace BNM_API
{
    /// <summary>
    /// Interaction logic for OPR.xaml
    /// </summary>
    public partial class OPR_Info : Window
    {
        internal static string? year { get; set; }
        internal static string? date { get; set; }

        internal static List<OPR_Model>? OPR_rate_list { get; set; }
        public OPR_Info()
        {
            InitializeComponent();

        }

        private async void year_comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = (ComboBoxItem)year_comboBox.SelectedValue;
            year = (string)item.Content;

            OPR_text.Text = null;
            change_rate_text.Text = null;

            try
            {
                OPR_rate_list = await OPR_Processor.Load_OPR();

                date_comboBox.Items.Clear();

                foreach (OPR_Model OPR_rate in OPR_rate_list)
                {
                    date_comboBox.Items.Add(OPR_rate.date);
                }

            }
            catch (Exception ex)
            {
                string message = "No data found";
                MessageBox.Show(message);
            }
        }

        private void date_comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            try
            {
                if (OPR_rate_list != null && date_comboBox.SelectedItem != null)
                {
                    foreach (OPR_Model OPR_rate in OPR_rate_list)
                    {
                        if (OPR_rate.date == date_comboBox.SelectedItem.ToString())
                        {
                            OPR_text.Text = OPR_rate.new_opr_level.ToString();
                            change_rate_text.Text = OPR_rate.change_in_opr.ToString();
                            break;
                        }
                        else
                        {
                            OPR_text.Text = null;
                            change_rate_text.Text = null;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                string message = "No data found";
                MessageBox.Show(message);
            }
        }

    }
}
