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
    /// Логика взаимодействия для BonusCardPage.xaml
    /// </summary>
    public partial class BonusCardPage : Page
    {
        private readonly BonusCardService _bonusCardService;
        private readonly CustomerService _customerService;


        public ObservableCollection<BonusCard> _bonusCards = new ObservableCollection<BonusCard>();
        public ObservableCollection<Customer> _customers = new ObservableCollection<Customer>();
        public BonusCardPage()
        {
            InitializeComponent();

            _customerService = new CustomerService();
            _bonusCardService = new BonusCardService();
            BonusCardDataGrid.ItemsSource = _bonusCards;
            CustomerComboBox.ItemsSource = _customers;
            NewCustomerComboBox.ItemsSource = _customers;

            HideElements();
            LoadDataAsync();
        }

        public void ShowElements()
        {
            DeleteBonusCardButton.Visibility = Visibility.Visible;
            DiscountLabel.Visibility = Visibility.Visible;
            PhoneLabel.Visibility = Visibility.Visible;
            NumberLabel.Visibility = Visibility.Visible;
            DiscountTextLabel.Visibility = Visibility.Visible;
            PhoneTextLabel.Visibility = Visibility.Visible;
            NumberTextLabel.Visibility = Visibility.Visible;
            NewCustomerTextLabel.Visibility = Visibility.Visible;
            NewDiscountTextLabel.Visibility = Visibility.Visible;
            NewCustomerComboBox.Visibility = Visibility.Visible;
            NewDiscountComboBox.Visibility = Visibility.Visible;
            NewNumberTextBox.Visibility = Visibility.Visible;
            NewNumberTextLabel.Visibility = Visibility.Visible;
        }

        public void HideElements()
        {
            DeleteBonusCardButton.Visibility = Visibility.Hidden;
            DiscountLabel.Visibility = Visibility.Hidden;
            PhoneLabel.Visibility = Visibility.Hidden;
            NumberLabel.Visibility = Visibility.Hidden;
            DiscountTextLabel.Visibility = Visibility.Hidden;
            PhoneTextLabel.Visibility = Visibility.Hidden;
            NumberTextLabel.Visibility = Visibility.Hidden;
            NewCustomerTextLabel.Visibility = Visibility.Hidden;
            NewDiscountTextLabel.Visibility = Visibility.Hidden;
            NewCustomerComboBox.Visibility = Visibility.Hidden;
            NewDiscountComboBox.Visibility = Visibility.Hidden;
            NewNumberTextBox.Visibility = Visibility.Hidden;
            NewNumberTextLabel.Visibility = Visibility.Hidden;
        }

        public async Task LoadDataAsync()
        {
            _bonusCards = await _bonusCardService.GetBonusCardsAsync();
            _customers = await _customerService.GetCustomersAsync();

            BonusCardDataGrid.ItemsSource = _bonusCards;
            CustomerComboBox.ItemsSource = _customers;
            NewCustomerComboBox.ItemsSource = _customers;

        }

        private async void AddBonusCardButton_Click(object sender, RoutedEventArgs e)
        {
            Customer customer = CustomerComboBox.SelectedItem as Customer;
            float discount = (float)Convert.ToDecimal(DiscountComboBox.Text);
            await _bonusCardService.AddBonusCardAsync(discount, customer);

            LoadDataAsync();
        }

        private async void FindBonusCardButton_Click(object sender, RoutedEventArgs e)
        {
            BonusCard bonusCard = new BonusCard();
            bonusCard = await _bonusCardService.GetBonusCardByNumberAsync(BonusCardNumberTextBox.Text);
            DiscountLabel.Content = bonusCard.discount.ToString();
            PhoneLabel.Content = bonusCard.Customer.ToString();
            NumberLabel.Content = bonusCard.number;

            ShowElements();

        }

        private async void DeleteBonusCardButton_Click(object sender, RoutedEventArgs e)
        {
            await _bonusCardService.DeleteBonusCardAsync(BonusCardNumberTextBox.Text);
            LoadDataAsync();
            HideElements();
        }

        private async void UpdateBonusCardButton_Click(object sender, RoutedEventArgs e)
        {
            Customer customer = new Customer();
            customer = NewCustomerComboBox.SelectedItem as Customer;
            float discount = (float)Convert.ToDecimal(NewDiscountComboBox.Text);
            await _bonusCardService.UpdateBonusCardAsync(BonusCardNumberTextBox.Text, NewNumberTextBox.Text, discount, customer);
            LoadDataAsync();
            HideElements();
        }
    }
}
