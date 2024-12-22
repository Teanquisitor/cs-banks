using OOPExample;
using System;
using System.Text;
using System.Windows.Forms;

namespace BankAccountApp
{
    public partial class MainForm : Form
    {
        //// Deposit for Checking Account
        //private void btnDepositChecking_Click(object sender, EventArgs e)
        //{
        //    if (decimal.TryParse(txtDepositAmount.Text, out decimal amount))
        //    {
        //        checking.Deposit(amount);
        //        txtDepositAmount.Clear();
        //    }
        //    else
        //    {
        //        MessageBox.Show("Invalid deposit amount!");
        //    }
        //}

        //// Withdraw from Checking Account
        //private void btnWithdrawChecking_Click(object sender, EventArgs e)
        //{
        //    if (decimal.TryParse(txtWithdrawAmount.Text, out decimal amount))
        //    {
        //        checking.Withdraw(amount);
        //        txtWithdrawAmount.Clear();
        //    }
        //    else
        //    {
        //        MessageBox.Show("Invalid withdrawal amount!");
        //    }
        //}

        //// Deposit for Savings Account
        //private void btnDepositSavings_Click(object sender, EventArgs e)
        //{
        //    if (decimal.TryParse(txtDepositAmount.Text, out decimal amount))
        //    {
        //        savings.Deposit(amount);
        //        txtDepositAmount.Clear();
        //    }
        //    else
        //    {
        //        MessageBox.Show("Invalid deposit amount!");
        //    }
        //}

        //// Withdraw from Savings Account
        //private void btnWithdrawSavings_Click(object sender, EventArgs e)
        //{
        //    if (decimal.TryParse(txtWithdrawAmount.Text, out decimal amount))
        //    {
        //        savings.Withdraw(amount);
        //        txtWithdrawAmount.Clear();
        //    }
        //    else
        //    {
        //        MessageBox.Show("Invalid withdrawal amount!");
        //    }
        //}

        // Calculate interest for Savings Account
        private void btnCalculateInterest_Click(object sender, EventArgs e)
        {
            var savingsAccount = savings as SavingsAccount;
            savingsAccount?.CalculateInterest();
        }

        // Display account information using reflection for Checking Account
        private void btnCheckingInfoReflection_Click(object sender, EventArgs e)
        {
            var checkingInfo = checking.GetType().GetProperties();
            var sb = new StringBuilder();
            foreach (var property in checkingInfo)
                sb.AppendLine($"{property.Name}: {property.GetValue(checking)}");

            MessageBox.Show(sb.ToString());
        }

        // Display account information using reflection for Savings Account
        private void btnSavingsInfoReflection_Click(object sender, EventArgs e)
        {
            var savingsInfo = savings.GetType().GetProperties();
            var sb = new StringBuilder();
            foreach (var property in savingsInfo)
                sb.AppendLine($"{property.Name}: {property.GetValue(savings)}");

            MessageBox.Show(sb.ToString());
        }
        
    }

}