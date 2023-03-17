using Newtonsoft.Json.Linq;
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

namespace BNM_API.Bank_Rates
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class BankInfo : Window
    {
        Dictionary<string, BankModel> BankDict = new Dictionary<string, BankModel>();

        public BankInfo()
        {
            InitializeComponent();
            PopulateBankComboBox();

        }

        public async void PopulateBankComboBox()
        {
            List<BankModel> bankList = await BankProcessor.LoadListOfBankNames();

            bank_name_comboBox.Items.Clear();

            foreach (BankModel bank in bankList)
            {
                bank_name_comboBox.Items.Add(bank.Bank_name);
            }

            if (bankList!= null)
            {
                SaveBankData(bankList);
            }

        }
        void SaveBankData(List<BankModel> listOfBanks)
        { 
            foreach (BankModel bank in listOfBanks)
            {
                BankDict.Add(bank.Bank_name, bank);
            }
        }

        private void bank_name_comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                string key = bank_name_comboBox.SelectedItem.ToString();

                if (BankDict.ContainsKey(key))
                {
                    BankDict.TryGetValue(key,out BankModel value);

                    bank_code_textBlock.Text = value.Bank_code;
                    bank_name_textBlock.Text = value.Bank_name;
                    base_rate_textBlock.Text = value.Base_rate.ToString();
                    base_lending_rate_textBlock.Text = value.Base_lending_rate.ToString();
                    eff_lending_rate_textBlock.Text = value.Indicative_eff_lending_rate.ToString();

                }

                else
                {
                    bank_code_textBlock.Text = null;
                    bank_name_textBlock.Text = null;
                    base_rate_textBlock.Text = null;
                    base_lending_rate_textBlock.Text = null;
                    eff_lending_rate_textBlock.Text = null;
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
