using MauiBankingApp.Models;
using MauiBankingApp.Services;

namespace MauiBankingApp.Views;

public partial class CustomerDetailsPage : ContentPage
{
    private readonly BankingService _bankingService;
    private readonly Customer _customer;
   


    public CustomerDetailsPage(BankingService bankingService, Customer customer)
    {
        InitializeComponent();
        _bankingService = bankingService;
        _customer = customer;

        BindingContext = _customer;


        //_refreshCallback = RefreshCustomerDetails;



    }

    private void RefreshCustomerDetails()
    {
        // Update the balance label
        BalanceLabel.Text = $"Balance: {_customer.Balance:C}";

        // Refresh transaction list
        TransactionsList.ItemsSource = null;
        TransactionsList.ItemsSource = _customer.Transactions.OrderByDescending(t => t.Date).ToList();
    }





    private async void OnAddTransactionClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AddTransactionPage(_bankingService, _customer, RefreshCustomerDetails));
    }
}
