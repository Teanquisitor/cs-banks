using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OOPExample
{
    // Abstract base class to define common behavior for different types of accounts
    public abstract partial class BankAccount
    {
        protected readonly SemaphoreSlim semaphore = new(1, 1);
        
        // Abstract method to deposit money, needs to be implemented by derived classes
        public abstract Task DepositAsync(decimal amount);

        // Abstract method to withdraw money, needs to be implemented by derived classes
        public abstract Task WithdrawAsync(decimal amount);

    }

    // Derived class for a Checking account
    public partial class CheckingAccount : BankAccount
    {
        // Implement DepositAsync for CheckingAccount
        public override async Task DepositAsync(decimal amount)
        {
            await semaphore.WaitAsync();
            try
            {
                await Task.Delay(50);
                Deposit(amount);
            }
            finally
            {
                semaphore.Release();
            }
        }

        // Implement WithdrawAsync for CheckingAccount with overdraft handling
        public override async Task WithdrawAsync(decimal amount)
        {
            await semaphore.WaitAsync();
            try
            {
                await Task.Delay(50); // Simulate delay for async operation
                Withdraw(amount);
            }
            finally
            {
                semaphore.Release();
            }
        }

    }

    // Derived class for a Savings account
    public partial class SavingsAccount : BankAccount
    {
        // Implement DepositAsync for SavingsAccount
        public override async Task DepositAsync(decimal amount)
        {
            await semaphore.WaitAsync();
            try
            {
                await Task.Delay(50);
                Deposit(amount);
            }
            finally
            {
                semaphore.Release();
            }
        }

        // Implement WithdrawAsync for SavingsAccount
        public override async Task WithdrawAsync(decimal amount)
        {
            await semaphore.WaitAsync();
            try
            {
                await Task.Delay(50); // Simulate delay for async operation
                Withdraw(amount);
            }
            finally
            {
                semaphore.Release();
            }
        }

    }

    //// Main class to demonstrate OOP concepts and polymorphism
    //class Program
    //{
    //    static async Task Main(string[] args)
    //    {
    //        // Create instances of CheckingAccount and SavingsAccount
    //        BankAccount checking = new CheckingAccount("Alice", 500m); // Alice's Checking Account with $500 overdraft
    //        BankAccount savings = new SavingsAccount("Bob", 5m); // Bob's Savings Account with 5% interest rate

    //        // Demonstrate polymorphism (both checking and savings accounts use DisplayAccountInfo method)
    //        checking.DisplayAccountInfo();
    //        savings.DisplayAccountInfo();

    //        // Perform asynchronous deposit and withdrawal operations
    //        var depositTasks = new List<Task>
    //        {
    //            checking.DepositAsync(200m), // Deposit into checking account
    //            savings.DepositAsync(300m)  // Deposit into savings account
    //        };

    //        var withdrawTasks = new List<Task>
    //        {
    //            checking.WithdrawAsync(50m), // Withdraw from checking account
    //            savings.WithdrawAsync(50m)   // Withdraw from savings account
    //        };

    //        await Task.WhenAll(depositTasks);
    //        await Task.WhenAll(withdrawTasks);

    //        // Demonstrate interest calculation for savings account
    //        SavingsAccount savingsAccount = savings as SavingsAccount; // Cast to access SavingsAccount specific features
    //        if (savingsAccount != null)
    //        {
    //            savingsAccount.CalculateInterest(); // Calculate interest for savings account
    //        }

    //        // Display final account information
    //        checking.DisplayAccountInfo();
    //        savings.DisplayAccountInfo();
    //    }
    //}
    
}