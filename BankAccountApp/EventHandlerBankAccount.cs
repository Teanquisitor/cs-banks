using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;

namespace OOPExample
{
    // Define a structure to demonstrate a 'struct' and 'unsafe' context
    public unsafe struct BankTransaction
    {
        public int TransactionId;
        public decimal Amount;
        public string TransactionType;

        // Pointer to a transaction message (unsafe)
        public fixed byte Message[256];

        // Method to simulate a transaction message (unsafe)
        public void SetMessage(string message)
        {
            // message.ToList().ForEach((character, index) =>
            // {
            //     if (index < 255)
            //         Message[index] = (byte)character;
            // });
        }

        // Method to display transaction info
        public void DisplayTransaction() =>
            Console.WriteLine($"Transaction ID: {TransactionId}, Type: {TransactionType}, Amount: {Amount:C}");
    }

    // Base abstract class for bank accounts
    public abstract partial class BankAccount
    {
        public event EventHandler BalanceChanged; // Event to notify balance change

        // Raise the event when balance changes
        protected void OnBalanceChanged() =>
            BalanceChanged?.Invoke(this, EventArgs.Empty);
    }

    //// Main class to demonstrate the usage of events, async, synchronization, boxing/unboxing, and dynamic
    //class Program
    //{
    //    // Use the event and async with synchronization to handle account updates
    //    static async Task Main(string[] args)
    //    {
    //        // Create instances of CheckingAccount and SavingsAccount
    //        BankAccount checking = new CheckingAccount("Alice", 500m);
    //        BankAccount savings = new SavingsAccount("Bob", 5m);

    //        // Subscribe to BalanceChanged event
    //        checking.BalanceChanged += AccountBalanceChanged;
    //        savings.BalanceChanged += AccountBalanceChanged;

    //        // Perform deposits and withdrawals asynchronously using lambdas
    //        var depositTasks = new List<Task>
    //         {
    //             DepositAsync(checking, 200m),
    //             DepositAsync(savings, 300m),
    //         };

    //        var withdrawTasks = new List<Task>
    //         {
    //             WithdrawAsync(checking, 50m),
    //             WithdrawAsync(savings, 50m)
    //         };

    //        await Task.WhenAll(depositTasks);
    //        await Task.WhenAll(withdrawTasks);

    //        // Perform dynamic operation - storing account in dynamic variable
    //        dynamic dynamicAccount = checking;
    //        dynamicAccount.Deposit(100m); // Dynamic dispatch for Deposit
    //        dynamicAccount.Withdraw(30m); // Dynamic dispatch for Withdraw

    //        // Boxing and Unboxing example
    //        object boxedBalance = checking.Balance; // Boxing
    //        decimal unboxedBalance = (decimal)boxedBalance; // Unboxing
    //        Console.WriteLine($"Unboxed balance: {unboxedBalance:C}");

    //        // Use unsafe code for handling a transaction
    //        BankTransaction transaction = new BankTransaction
    //        {
    //            TransactionId = 12345,
    //            Amount = 200m,
    //            TransactionType = "Deposit"
    //        };

    //        // Setting message with unsafe code
    //        transaction.SetMessage("Transaction Successful!");
    //        transaction.DisplayTransaction();

    //        // Display account information
    //        checking.DisplayAccountInfo();
    //        savings.DisplayAccountInfo();
    //    }

    //    // Event handler for balance changes
    //    private static void AccountBalanceChanged(object sender, EventArgs e)
    //    {
    //        var account = sender as BankAccount;
    //        if (account != null)
    //        {
    //            Console.WriteLine($"{account.AccountHolder}'s balance has changed. New Balance: {account.Balance:C}");
    //        }
    //    }

    //    // Asynchronous Deposit method
    //    static async Task DepositAsync(BankAccount account, decimal amount)
    //    {
    //        await Task.Delay(100); // Simulate async operation
    //        account.Deposit(amount);
    //    }

    //    // Asynchronous Withdraw method
    //    static async Task WithdrawAsync(BankAccount account, decimal amount)
    //    {
    //        await Task.Delay(100); // Simulate async operation
    //        account.Withdraw(amount);
    //    }
    //}
    
}