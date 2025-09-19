using MauiBankingApp.Models;
using MauiBankingApp.Services;

namespace MauiBankingApp.Views;

public partial class AddTransactionPage : ContentPage
{
    private readonly BankingService _bankingService;
    private readonly Customer _customer;
    private readonly Action _onTransactionAdded; // ✅ single callback field

    public AddTransactionPage(BankingService bankingService, Customer customer, Action onTransactionAdded)
    {
        InitializeComponent();
        _bankingService = bankingService;
        _customer = customer;
        _onTransactionAdded = onTransactionAdded;

        // Optional: populate transaction type picker
        TransactionTypePicker.ItemsSource = Enum.GetNames(typeof(TransactionType));
        TransactionTypePicker.SelectedIndex = 0;
    }

    private async void OnSaveTransactionClicked(object sender, EventArgs e)
    {
        if (TransactionTypePicker.SelectedIndex == -1)
        {
            await DisplayAlert("Error", "Please select a transaction type.", "OK");
            return;
        }

        if (!decimal.TryParse(AmountEntry.Text, out var amount) || amount <= 0)
        {
            await DisplayAlert("Error", "Please enter a valid amount.", "OK");
            return;
        }

        var type = TransactionTypePicker.SelectedIndex == 0
            ? TransactionType.Deposit
            : TransactionType.Withdrawal;

        if (type == TransactionType.Withdrawal && _customer.Balance < amount)
        {
            await DisplayAlert("Error", "Insufficient balance for withdrawal.", "OK");
            return;
        }

        var transaction = new Transaction
        {
            Type = type,
            Amount = amount,
            Description = DescriptionEntry.Text ?? "",
            Date = DateTime.Now
        };

        _bankingService.AddTransaction(_customer.Id, transaction);

        // ✅ Refresh the CustomerDetailsPage
        _onTransactionAdded?.Invoke();

        await DisplayAlert("Success", "Transaction saved.", "OK");
        await Navigation.PopAsync();
    }
}

