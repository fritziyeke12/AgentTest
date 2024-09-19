using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace NotifyWindow
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(string message)/* : this()*/
        {
            InitializeComponent();
            messageLabel.Text = message;
            //Topmost = true;
            //DisplayMessage(message);  // Display the message on the WPF window
            //Task.Run(() => LoadDataAsync(message));  // Run on a background thread
        }
    }
}