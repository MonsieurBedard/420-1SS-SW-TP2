using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using DogFetchApp.Properties;

namespace DogFetchApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            string lang = DogFetchApp.Properties.Settings.Default.Language;
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(lang);
        }
    }
}
