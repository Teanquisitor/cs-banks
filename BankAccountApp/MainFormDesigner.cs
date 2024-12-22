
namespace BankAccountApp
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblCheckingInfo;
        private Label lblSavingsInfo;
        private Button btnDepositChecking;
        private Button btnWithdrawChecking;
        private Button btnDepositSavings;
        private Button btnWithdrawSavings;
        private TextBox txtDepositAmount;
        private TextBox txtWithdrawAmount;
        private Button btnCalculateInterest;
        private Button btnCheckingInfoReflection;
        private Button btnSavingsInfoReflection;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblCheckingInfo = new Label();
            lblSavingsInfo = new Label();
            btnDepositChecking = new Button();
            btnWithdrawChecking = new Button();
            btnDepositSavings = new Button();
            btnWithdrawSavings = new Button();
            txtDepositAmount = new TextBox();
            txtWithdrawAmount = new TextBox();
            btnCalculateInterest = new Button();
            btnCheckingInfoReflection = new Button();
            btnSavingsInfoReflection = new Button();

            SuspendLayout();
            // 
            // lblCheckingInfo
            // 
            lblCheckingInfo.AutoSize = true;
            lblCheckingInfo.Location = new System.Drawing.Point(12, 9);
            lblCheckingInfo.Name = "lblCheckingInfo";
            lblCheckingInfo.Size = new System.Drawing.Size(199, 13);
            lblCheckingInfo.TabIndex = 0;
            lblCheckingInfo.Text = "Checking Account: Alice, Balance: $0.00";
            // 
            // lblSavingsInfo
            // 
            lblSavingsInfo.AutoSize = true;
            lblSavingsInfo.Location = new System.Drawing.Point(12, 40);
            lblSavingsInfo.Name = "lblSavingsInfo";
            lblSavingsInfo.Size = new System.Drawing.Size(193, 13);
            lblSavingsInfo.TabIndex = 1;
            lblSavingsInfo.Text = "Savings Account: Bob, Balance: $0.00";
            // 
            // btnDepositChecking
            // 
            btnDepositChecking.Location = new System.Drawing.Point(15, 66);
            btnDepositChecking.Name = "btnDepositChecking";
            btnDepositChecking.Size = new System.Drawing.Size(75, 23);
            btnDepositChecking.TabIndex = 2;
            btnDepositChecking.Text = "Deposit Checking";
            btnDepositChecking.UseVisualStyleBackColor = true;
            btnDepositChecking.Click += new EventHandler(btnDepositChecking_Click);
            // 
            // btnWithdrawChecking
            // 
            btnWithdrawChecking.Location = new System.Drawing.Point(96, 66);
            btnWithdrawChecking.Name = "btnWithdrawChecking";
            btnWithdrawChecking.Size = new System.Drawing.Size(75, 23);
            btnWithdrawChecking.TabIndex = 3;
            btnWithdrawChecking.Text = "Withdraw Checking";
            btnWithdrawChecking.UseVisualStyleBackColor = true;
            btnWithdrawChecking.Click += new EventHandler(btnWithdrawChecking_Click);
            // 
            // btnDepositSavings
            // 
            btnDepositSavings.Location = new System.Drawing.Point(15, 95);
            btnDepositSavings.Name = "btnDepositSavings";
            btnDepositSavings.Size = new System.Drawing.Size(75, 23);
            btnDepositSavings.TabIndex = 4;
            btnDepositSavings.Text = "Deposit Savings";
            btnDepositSavings.UseVisualStyleBackColor = true;
            btnDepositSavings.Click += new EventHandler(btnDepositSavings_Click);
            // 
            // btnWithdrawSavings
            // 
            btnWithdrawSavings.Location = new System.Drawing.Point(96, 95);
            btnWithdrawSavings.Name = "btnWithdrawSavings";
            btnWithdrawSavings.Size = new System.Drawing.Size(75, 23);
            btnWithdrawSavings.TabIndex = 5;
            btnWithdrawSavings.Text = "Withdraw Savings";
            btnWithdrawSavings.UseVisualStyleBackColor = true;
            btnWithdrawSavings.Click += new EventHandler(btnWithdrawSavings_Click);
            // 
            // txtDepositAmount
            // 
            txtDepositAmount.Location = new System.Drawing.Point(15, 124);
            txtDepositAmount.Name = "txtDepositAmount";
            txtDepositAmount.Size = new System.Drawing.Size(100, 20);
            txtDepositAmount.TabIndex = 6;
            txtDepositAmount.PlaceholderText = "Amount to Deposit";
            // 
            // txtWithdrawAmount
            // 
            txtWithdrawAmount.Location = new System.Drawing.Point(15, 150);
            txtWithdrawAmount.Name = "txtWithdrawAmount";
            txtWithdrawAmount.Size = new System.Drawing.Size(100, 20);
            txtWithdrawAmount.TabIndex = 7;
            txtWithdrawAmount.PlaceholderText = "Amount to Withdraw";
            // 
            // btnCalculateInterest
            // 
            btnCalculateInterest.Location = new System.Drawing.Point(15, 176);
            btnCalculateInterest.Name = "btnCalculateInterest";
            btnCalculateInterest.Size = new System.Drawing.Size(120, 23);
            btnCalculateInterest.TabIndex = 8;
            btnCalculateInterest.Text = "Calculate Interest (Savings)";
            btnCalculateInterest.UseVisualStyleBackColor = true;
            btnCalculateInterest.Click += new EventHandler(btnCalculateInterest_Click);
            //
            // btnCheckingInfoReflection
            //
            btnCheckingInfoReflection.Location = new System.Drawing.Point(15, 205);
            btnCheckingInfoReflection.Name = "btnCheckingInfoReflection";
            btnCheckingInfoReflection.Size = new System.Drawing.Size(160, 23);
            btnCheckingInfoReflection.TabIndex = 9;
            btnCheckingInfoReflection.Text = "Checking Info (Reflection)";
            btnCheckingInfoReflection.UseVisualStyleBackColor = true;
            btnCheckingInfoReflection.Click += new EventHandler(btnCheckingInfoReflection_Click);
            //
            // btnSavingsInfoReflection
            //
            btnSavingsInfoReflection.Location = new System.Drawing.Point(15, 235);
            btnSavingsInfoReflection.Name = "btnSavingsInfoReflection";
            btnSavingsInfoReflection.Size = new System.Drawing.Size(160, 23);
            btnSavingsInfoReflection.TabIndex = 10;
            btnSavingsInfoReflection.Text = "Savings Info (Reflection)";
            btnSavingsInfoReflection.UseVisualStyleBackColor = true;
            btnSavingsInfoReflection.Click += new EventHandler(btnSavingsInfoReflection_Click);
            // 
            // MainForm
            // 
            ClientSize = new System.Drawing.Size(284, 277);
            Controls.Add(btnCheckingInfoReflection);
            Controls.Add(btnSavingsInfoReflection);
            Controls.Add(btnCalculateInterest);
            Controls.Add(txtWithdrawAmount);
            Controls.Add(txtDepositAmount);
            Controls.Add(btnWithdrawSavings);
            Controls.Add(btnDepositSavings);
            Controls.Add(btnWithdrawChecking);
            Controls.Add(btnDepositChecking);
            Controls.Add(lblSavingsInfo);
            Controls.Add(lblCheckingInfo);
            Name = "MainForm";
            Text = "Bank Account App";
            ResumeLayout(false);
            PerformLayout();
        }
        
    }

}