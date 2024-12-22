using OOPExample;

namespace TestProject
{
    public class BankAccountTests
    {
        private BankAccount checkingAccount;
        private BankAccount savingsAccount;
        private const decimal overdraftLimit = 500m;
        private const decimal interestRate = 5m;
        private const decimal initialAmount = 500m;

        public BankAccountTests()
        {
            checkingAccount = new CheckingAccount("Alice", overdraftLimit);
            checkingAccount.DepositAsync(initialAmount).Wait();

            savingsAccount = new SavingsAccount("Bob", interestRate);
            savingsAccount.DepositAsync(initialAmount).Wait();
        }

        #region Checking Account Tests

        [Fact]
        public void Checking_BankAccount_Reflection()
        {
            var type = checkingAccount.GetType();
            var properties = type.GetProperties();
            var methods = type.GetMethods();

            Assert.Contains(properties, p => p.Name == "Balance");
            Assert.Contains(methods, m => m.Name == "DepositAsync");
            Assert.Contains(methods, m => m.Name == "WithdrawAsync");
        }

        [Fact]
        public async Task Checking_Deposit_ValidAmount_IncreasesBalance()
        {
            var depositAmount = 100m;

            await checkingAccount.DepositAsync(depositAmount);

            Assert.Equal(initialAmount + depositAmount, checkingAccount.Balance);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-100)]
        public async Task Checking_Deposit_InvalidAmount_DoesNotChangeBalance(decimal amount)
        {
            await checkingAccount.DepositAsync(amount);

            Assert.Equal(initialAmount, checkingAccount.Balance);
        }

        [Fact]
        public async Task Checking_Withdraw_ValidAmount_DecreasesBalance()
        {
            var withdrawAmount = 100m;

            await checkingAccount.WithdrawAsync(withdrawAmount);

            Assert.Equal(initialAmount - withdrawAmount, checkingAccount.Balance);
        }

        [Fact]
        public async Task Checking_Withdraw_Overdraw_DoesNotChangeBalance()
        {
            await checkingAccount.WithdrawAsync(initialAmount + overdraftLimit + 1m);

            Assert.Equal(initialAmount, checkingAccount.Balance);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-100)]
        public async Task Checking_Withdraw_InvalidAmount_DoesNotChangeBalance(decimal amount)
        {
            await checkingAccount.WithdrawAsync(amount);

            Assert.Equal(initialAmount, checkingAccount.Balance);
        }

        [Fact]
        public async Task Checking_ConcurrentDeposits_IncreasesBalanceCorrectly()
        {
            var tasks = new Task[10];
            var depositAmount = 100m;

            for (var i = 0; i < tasks.Length; i++)
                tasks[i] = checkingAccount.DepositAsync(depositAmount);
            await Task.WhenAll(tasks);

            Assert.Equal(initialAmount + tasks.Length * depositAmount, checkingAccount.Balance);
        }

        [Fact]
        public async Task Checking_ConcurrentWithdrawals_DecreasesBalanceCorrectly()
        {
            var tasks = new Task[10];
            var withdrawAmount = 50m;

            for (var i = 0; i < tasks.Length; i++)
                tasks[i] = checkingAccount.WithdrawAsync(withdrawAmount);
            await Task.WhenAll(tasks);

            Assert.Equal(0m, checkingAccount.Balance);
        }

        [Fact]
        public async Task Checking_Withdraw_OverdraftLimit()
        {
            var withdrawalAmount = initialAmount + overdraftLimit - 1m;

            await checkingAccount.WithdrawAsync(withdrawalAmount);

            Assert.Equal(initialAmount-withdrawalAmount, checkingAccount.Balance);
        }

        #endregion

        #region Savings Account Tests

        [Fact]
        public void Savings_CalculateInterest_IncreasesBalance()
        {
            ((SavingsAccount)savingsAccount).CalculateInterest();

            Assert.Equal(initialAmount + (initialAmount * interestRate / 100), savingsAccount.Balance);
        }

        [Fact]
        public async Task Savings_Deposit_ValidAmount_IncreasesBalance()
        {
            var depositAmount = 100m;

            await savingsAccount.DepositAsync(depositAmount);

            Assert.Equal(initialAmount + depositAmount, savingsAccount.Balance);
        }

        [Fact]
        public async Task Savings_Withdraw_ValidAmount_DecreasesBalance()
        {
            var withdrawAmount = 100m;

            await savingsAccount.WithdrawAsync(withdrawAmount);

            Assert.Equal(initialAmount - withdrawAmount, savingsAccount.Balance);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-100)]
        public async Task Savings_Deposit_InvalidAmount_DoesNotChangeBalance(decimal amount)
        {
            await savingsAccount.DepositAsync(amount);

            Assert.Equal(initialAmount, savingsAccount.Balance);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-100)]
        public async Task Savings_Withdraw_InvalidAmount_DoesNotChangeBalance(decimal amount)
        {
            await savingsAccount.WithdrawAsync(amount);

            Assert.Equal(initialAmount, savingsAccount.Balance);
        }

        [Fact]
        public void Savings_ConcurrentDeposits_IncreasesBalanceCorrectly()
        {
            var tasks = new Task[10];
            var depositAmount = 100m;

            for (var i = 0; i < tasks.Length; i++)
                tasks[i] = Task.Run(() => savingsAccount.DepositAsync(depositAmount));
            Task.WaitAll(tasks);

            Assert.Equal(initialAmount + tasks.Length * depositAmount, savingsAccount.Balance);
        }

        [Fact]
        public void Savings_ConcurrentWithdrawals_DecreasesBalanceCorrectly()
        {
            var tasks = new Task[10];
            var withdrawAmount = 50m;

            for (var i = 0; i < tasks.Length; i++)
                tasks[i] = Task.Run(() => savingsAccount.WithdrawAsync(withdrawAmount));
            Task.WaitAll(tasks);

            Assert.Equal(initialAmount - tasks.Length * withdrawAmount, savingsAccount.Balance);
        }

        #endregion

    }

}