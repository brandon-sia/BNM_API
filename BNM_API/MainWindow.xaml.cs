﻿using BNM_API.Bank_Rates;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BNM_API
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ApiHelper.InitializeClient();
        }

        private void Exchange_Rates_Click(object sender, RoutedEventArgs e)
        {

            RateInfo exchange_rate_info = new();
            exchange_rate_info.Show();
        }

        private void OPR_Click(object sender, RoutedEventArgs e)
        {
            OPR_Info opr_info = new();
            opr_info.Show();
        }

        private void Bank_Click(object sender, RoutedEventArgs e)
        {
            BankInfo bank_info = new();
            bank_info.Show();
        }
    }
}
