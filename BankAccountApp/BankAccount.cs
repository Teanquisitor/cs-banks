using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing.Text;

namespace OOPExample
{
    // Abstract base class to define common behavior for different types of accounts
    public abstract partial class BankAccount(string accountHolder)  : IDisposable
    {
        public string AccountHolder { get; set; } = accountHolder;
        public decimal Balance { get; private set; }  = 0m; // Initially, balance is zero

        protected decimal DecreaseBalance(decimal amount) =>
            Balance -= amount;

        // Virtual method for Deposit, allowing it to be overridden in derived classes
        protected virtual void Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Deposit amount must be positive.");
                return;
            }

            // Modify the account sum
            Balance += amount;
            OnBalanceChanged(); // Trigger event when balance changes
            Console.WriteLine($"Deposited {amount:C} into Base Bank Account.");
        }

        // Abstract method to withdraw money, needs to be implemented by derived classes
        protected abstract void Withdraw(decimal amount);

        // Method to display account details (common functionality for all accounts)
        public void DisplayAccountInfo() =>
            Console.WriteLine($"Account Holder: {AccountHolder}, Balance: {Balance:C}");

        public void Dispose()
        {
            // All BankAccount resources are managed, so no need to do anything here

            Console.WriteLine($"Disposing account for {AccountHolder}.");
            GC.SuppressFinalize(this);
        }
    }

    // Derived class for a Checking account
    public partial class CheckingAccount(string accountHolder, decimal overdraftLimit) : BankAccount(accountHolder)
    {
        public decimal OverdraftLimit { get; private set; } = overdraftLimit;

        // Override Deposit method for CheckingAccount
        protected override void Deposit(decimal amount)
        {
            // Check the amount first
            if (amount > 0)
            {
                base.Deposit(amount);
                return;
            }

            Console.WriteLine("Deposit amount must be positive.");
        }

        protected override void Withdraw(decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Withdrawal amount must be positive.");
                return;
            }

            // Check the amount again
            if (Balance - amount >= -OverdraftLimit)
            {
                DecreaseBalance(amount);
                OnBalanceChanged(); // Trigger event when balance changes
                Console.WriteLine($"Withdrew {amount:C} from Checking Account.");
                return;
            }

            Console.WriteLine($"Withdrawal denied. Insufficient funds for this withdrawal.");
        }

    }

    // Derived class for a Savings account
    public partial class SavingsAccount(string accountHolder, decimal interestRate) : BankAccount(accountHolder)
    {
        public decimal InterestRate { get; private set; } = interestRate;

        protected override void Withdraw(decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Withdrawal amount must be positive.");
                return;
            }

            if (Balance >= amount)
            {
                DecreaseBalance(amount);
                OnBalanceChanged(); // Trigger event when balance changes
                Console.WriteLine($"Withdrew {amount:C} from Savings Account.");
                return;
            }

            Console.WriteLine($"Withdrawal denied. Insufficient funds in Savings Account.");
        }

        // Method to calculate and add interest
        public void CalculateInterest()
        {
            decimal interest = Balance * InterestRate / 100;
            Deposit(interest);
            Console.WriteLine($"Interest of {interest:C} added to Savings Account.");
        }

    }

    // Main class, shows polymorphism
    // class Program
    // {
    //     static void Main(string[] args)
    //     {
    //        // Create instances of CheckingAccount and SavingsAccount
    //        BankAccount checking = new CheckingAccount("Alice", 500m);
    //        BankAccount savings = new SavingsAccount("Bob", 5m);

    //        // Polymorphism: Both accounts use DisplayAccountInfo method
    //        checking.DisplayAccountInfo();
    //        savings.DisplayAccountInfo();

    //        // Perform deposit and withdrawal operations
    //        checking.Deposit(200m); // Deposits into checking account
    //        savings.Deposit(300m); // Deposits into savings account

    //        checking.Withdraw(50m); // Withdraw from checking account
    //        savings.Withdraw(50m); // Withdraw from savings account

    //        // Demonstrate interest calculation for savings account
    //        if (savings is SavingsAccount savingsAccount)
    //            savingsAccount.CalculateInterest();

    //        // Display final account details
    //        checking.DisplayAccountInfo(); 
    //        savings.DisplayAccountInfo();
    //     }

    // }

}