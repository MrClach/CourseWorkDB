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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace for_db7.Pages
{
    /// <summary>
    /// Логика взаимодействия для CustomerPage.xaml
    /// </summary>
    public partial class CustomerPage : Page
    {
        private readonly CustomerService _customerService;

        public ObservableCollection<Customer> _customers = new ObservableCollection<Customer>();

        public CustomerPage()
        {
            InitializeComponent();

            _customerService = new CustomerService();

            AllCustomersDataGrid.ItemsSource = _customers;
            LoadDataAsync();

            HideElements();
        }

        public void HideElements()
        {
            UpdateNameTextBox.Visibility = Visibility.Hidden;
            UpdateAgeTextBox.Visibility = Visibility.Hidden;
            UpdateGenderTextBox.Visibility = Visibility.Hidden;
            UpdatePhoneTextBox.Visibility = Visibility.Hidden;
            ChangeCustomerButton.Visibility = Visibility.Hidden;
            DeleteCustomerButton.Visibility = Visibility.Hidden;
        }

        public void ShowElements()
        {
            UpdateNameTextBox.Visibility = Visibility.Visible;
            UpdateAgeTextBox.Visibility = Visibility.Visible;
            UpdateGenderTextBox.Visibility = Visibility.Visible;
            UpdatePhoneTextBox.Visibility = Visibility.Visible;
            DeleteCustomerButton.Visibility = Visibility.Visible;
            ChangeCustomerButton.Visibility = Visibility.Visible;
        }

        public async Task LoadDataAsync()
        {
            _customers = await _customerService.GetCustomersAsync();
            AllCustomersDataGrid.ItemsSource = _customers;
        }

        private async void AddCustomerButton_Click(object sender, RoutedEventArgs e)
        {
            await _customerService.AddCustomerAsync(AddCustomerNameTextBox.Text, Convert.ToInt32(AddCustomerAgeTextBox.Text), AddCustomerGenderTextBox.Text, AddCustomerPhoneTextBox.Text);
            LoadDataAsync();
        }

        private async void FindCustomerButton_Click(object sender, RoutedEventArgs e)
        {
            Customer customer = await _customerService.GetCustomerByPhoneAsync(FindCustomerByPhoneTextBox.Text);
            UpdateNameTextBox.Text = customer.secondName;
            UpdateAgeTextBox.Text = customer.age.ToString();
            UpdateGenderTextBox.Text = customer.gender;
            UpdatePhoneTextBox.Text = customer.phoneNumber;

            ShowElements();

        }

        private async void DeleteCustomerButton_Click(object sender, RoutedEventArgs e)
        {
            await _customerService.DeleteCustomerAsync(FindCustomerByPhoneTextBox.Text);
            LoadDataAsync();
            HideElements();
        }

        private async void ChangeCustomerButton_Click(object sender, RoutedEventArgs e)
        {
            await _customerService.UpdateCustomerAsync(FindCustomerByPhoneTextBox.Text, UpdateNameTextBox.Text, Convert.ToInt32(UpdateAgeTextBox.Text), UpdateGenderTextBox.Text, UpdatePhoneTextBox.Text);
            LoadDataAsync();
            HideElements();

        }
    }
}
