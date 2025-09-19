using MauiBankingApp.Models;
using MauiBankingApp.Services;

namespace MauiBankingApp.Views;

public partial class AddCustomerPage : ContentPage
{
    private readonly BankingService _bankingService;
    private readonly Action _onCustomerAdded; // single callback field

    // ✅ Constructor now takes 2 arguments
    public AddCustomerPage(BankingService bankingService, Action onCustomerAdded)
    {
        InitializeComponent();
        _bankingService = bankingService;
        _onCustomerAdded = onCustomerAdded;
    }

    private async void OnSaveClicked(object sender, EventArgs e)
    {

        var bank = new Bank
        {
            BankName = BankNameEntry.Text,
            BankAddress = BankAddressEntry.Text,
            BranchCode = BranchCodeEntry.Text,
            ContactPhoneNumber = ContactPhoneNumberEntry.Text,
            ContactEmail = ContactEmailEntry.Text,
            OperatingHours = OperatingHoursEntry.Text
        };


        // Create new customer
        var customer = new Customer
        {
            FirstName = FirstNameEntry.Text,
            LastName = LastNameEntry.Text,
            Email = EmailEntry.Text,
            PhoneNumber = PhoneEntry.Text,
            IdentityNumber = IdentityNumberEntry.Text,
            Gender = GenderPicker.SelectedItem?.ToString(),
            Nationality = NationalityEntry.Text,
            MaritalStatus = MaritalStatusPicker.SelectedItem?.ToString(),
            EmploymentStatus = EmploymentStatusPicker.SelectedItem?.ToString(),
            Balance = 0,
            Transactions = new List<Transaction>(),
            Bank = bank
        };

        _bankingService.AddCustomer(customer);

        // Call the callback to refresh the list
        _onCustomerAdded?.Invoke();

        await DisplayAlert("Success", "Customer added", "OK");
        await Navigation.PopAsync();
    }

    private async void OnCancelClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}

