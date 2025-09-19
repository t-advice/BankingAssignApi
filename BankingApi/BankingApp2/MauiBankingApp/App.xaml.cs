using MauiBankingApp.Services;
using MauiBankingApp.Views;

namespace MauiBankingApp;

public partial class App : Application
{
    private readonly BankingService _bankingService = new();

    public App()
    {
        InitializeComponent();

        MainPage = new NavigationPage(new CustomerListPage(_bankingService));
    }
}
