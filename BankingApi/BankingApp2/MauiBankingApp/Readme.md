# MAUI Banking App

## Overview

This is a **.NET MAUI cross-platform mobile application** that simulates a simple banking system.  
The app allows users to:

- View a list of banking customers
- Add new customers with full personal and bank details
- View customer details including transactions and bank info
- Perform deposit and withdrawal transactions
- Automatically update customer balances

> **Note:** This version uses **in-memory storage** for demonstration purposes. No SQLite or persistent database is used. Future versions will connect to an API backend via HttpClient.

---

## Features

### Customer Management

- Display a list of all customers with:
  - Name, Email, Phone Number
  - Current balance
  - Bank name
- View individual customer details including:
  - Identity Number, Gender, Nationality
  - Marital Status, Employment Status
  - Full bank details: Bank Name, Address, Branch Code, Phone, Email, Operating Hours
- Add new customers with all personal and bank information

### Transactions

- Add deposit and withdrawal transactions per customer
- Automatically update customer balances after each transaction
- Display a chronological transaction history in the customer details page

### UI Features

- Scrollable forms for adding customers
- Buttons for saving/canceling actions
- “View Details” button for each customer
- Fully functional navigation between pages

---

## Project Structure

- **Models** – Data models including `Customer`, `Bank`, `Transaction`  
- **Services** – `BankingService` that manages in-memory storage and business logic  
- **Views** – UI pages:
  - `CustomerListPage` – List of customers  
  - `AddCustomerPage` – Form to add a new customer  
  - `CustomerDetailsPage` – Displays customer and bank info, and transaction history  
  - `AddTransactionPage` – Add deposit/withdrawal transactions  
- **App.xaml / AppShell.xaml** – App startup and navigation configuration

---

## Getting Started

1. Clone the repository:

```bash
git clone <your-repo-url>
