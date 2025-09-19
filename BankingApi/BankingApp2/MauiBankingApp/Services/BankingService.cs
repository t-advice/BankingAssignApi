using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MauiBankingApp.Models;

namespace MauiBankingApp.Services
{
    public class BankingService
    {
        private readonly List<Customer> _customers;

        public BankingService()
        {
            var alphaBank = new Bank
            {
                BankName = "Alpha Bank",
                BankAddress = "123 Main St, MetroPolis",
                BranchCode = "ALP001",
                ContactPhoneNumber = "555-1000",
                ContactEmail = "contact@alphabank.com",
                OperatingHours = "Mon-Fri 9am-5pm",
            };
            var betaBank = new Bank
            {
                BankName = "Beta Bank",
                BankAddress = "456 Oak Ave, Gotham",
                BranchCode = "BB002",
                ContactPhoneNumber = "555-2000",
                ContactEmail = "info@betabank.com",
                OperatingHours = "8am-4pm"
            };

            _customers = new List<Customer>
            {

                new Customer
                {
                    Id = 1,
                    FirstName = "John",
                    LastName = "Doe",
                    Email = "john.doe@email.com",
                    PhoneNumber = "555-1234",
                    PhysicalAddress = "101 Maple Street",
                    IdentityNumber = "A123456789",
                    Gender = "Male",
                    Nationality = "USA",
                    MaritalStatus = "Single",
                    EmploymentStatus = "Employed",
                    Bank = alphaBank,
                    Balance = 5000


                },
                new Customer
                {
                    Id = 2,
                    FirstName = "Jane",
                    LastName = "Smith",
                    Email = "jane.smith@email.com",
                    PhoneNumber = "555-5678",
                    PhysicalAddress = "202 Pine Avenue",
                    IdentityNumber = "B987654321",
                    Gender = "Female",
                    Nationality = "USA",
                    MaritalStatus = "Married",
                    EmploymentStatus = "Self-Employed",
                    Bank = betaBank,
                    Balance = 7000

                },
            };
        }
        public List<Customer> GetCustomers() => _customers;
        public void AddCustomer(Customer customer)
        {
            customer.Id = _customers.Any() ? _customers.Max(c => c.Id) + 1 : 1;
            _customers.Add(customer);
        }

        public void AddTransaction( int customerId, Transaction transaction)
        {
            var customer = _customers.FirstOrDefault(c => c.Id == customerId);
            if (customer != null)
            {
                if (transaction.Type == TransactionType.Withdrawal && customer.Balance >= transaction.Amount)
                {
                    customer.Balance -= transaction.Amount;
                }
                else if (transaction.Type == TransactionType.Deposit)
                {
                    customer.Balance += transaction.Amount;
                }

                transaction.Id = customer.Transactions.Count + 1;
                customer.Transactions.Add(transaction);
            }
        }

    }
}
