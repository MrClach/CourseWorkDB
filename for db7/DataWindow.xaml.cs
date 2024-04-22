using for_db7.Pages;
using spp3.Data.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace for_db7
{
    /// <summary>
    /// Логика взаимодействия для DataWindow.xaml
    /// </summary>
    public partial class DataWindow : Window
    {
        public DataWindow()
        {
            InitializeComponent();
        }

        private void CustomerPageButton_Click(object sender, RoutedEventArgs e)
        {
            ActiveFrame.Navigate(new Uri("Pages/CustomerPage.xaml", UriKind.Relative));
        }

        private void BonusCardPageButton_Click(object sender, RoutedEventArgs e)
        {
            ActiveFrame.Navigate(new Uri("Pages/BonusCardPage.xaml", UriKind.Relative));
        }
    }
}
