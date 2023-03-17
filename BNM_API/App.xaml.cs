using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace BNM_API
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    /// 

    interface IJsonObject<T_One>
    {
        public T_One meta { get; set; }
    }

    public partial class App : Application
    {
    }
}
