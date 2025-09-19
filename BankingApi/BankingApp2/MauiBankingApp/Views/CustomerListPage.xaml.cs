using MauiBankingApp.Models;
using MauiBankingApp.Services;

namespace MauiBankingApp.Views;

public partial class CustomerListPage : ContentPage
{
    private readonly BankingService _bankingService;
    public List<Customer> Customers { get; set; }

    public CustomerListPage(BankingService bankingService)
    {
        InitializeComponent();
        _bankingService = bankingService;

        // Load customers into property and bind to XAML
        Customers = _bankingService.GetCustomers();
        BindingContext = this;

        // Populate CollectionView
        LoadCustomers();
    }

    /// <summary>
    /// Refreshes the CollectionView with the current customers
    /// </summary>
    private void LoadCustomers()
    {
        CustomerList.ItemsSource = null;
        CustomerList.ItemsSource = _bankingService.GetCustomers();
    }

    /// <summary>
    /// Handles tapping on a customer
    /// </summary>
    private async void OnCustomerSelected(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.Count == 0)
            return;

        if (e.CurrentSelection.FirstOrDefault() is Customer selectedCustomer)
        {
            // Navigate to CustomerDetailsPage
            await Navigation.PushAsync(new CustomerDetailsPage(_bankingService, selectedCustomer));
        }

        // Deselect immediately so same customer can be tapped again
        if (sender is CollectionView cv)
            cv.SelectedItem = null;
    }

    private async void OnViewDetailsClicked(object sender, EventArgs e)
    {
        if (sender is Button btn && btn.BindingContext is Customer customer)
        {
            // Navigate and wait for the page to close
            var detailsPage = new CustomerDetailsPage(_bankingService, customer);
            await Navigation.PushAsync(detailsPage);

            // Refresh the CollectionView so balances update
            LoadCustomers();
        }
    }
    private async void OnAddCustomerClicked(object sender, EventArgs e)
    {
        // Pass LoadCustomers as callback to refresh list after adding a new customer
        await Navigation.PushAsync(new AddCustomerPage(_bankingService, LoadCustomers));
    }
}


