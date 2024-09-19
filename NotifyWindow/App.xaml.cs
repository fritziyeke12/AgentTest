using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace NotifyWindow
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            string message = e.Args.Length > 0 ?/* string.Join(" ", e.Args)*/ e.Args[0] : "No message provided";

            // Create and show MainWindow with the message
            MainWindow mainWindow = new MainWindow(message);
            mainWindow.Show();
        }
    }
}
