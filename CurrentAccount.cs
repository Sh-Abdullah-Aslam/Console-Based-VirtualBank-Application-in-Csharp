using System;
using System.Collections.Generic;
using System.Text;

namespace VP_Lab_2
{
    class CurrentAccount : Account
    {
        // Data-members
        private double withdrawalLimit;

        // Properties
        public double WithdrawalLimit
        {
            set { this.withdrawalLimit = value; }
            get { return this.withdrawalLimit; }
        }

        // Constructors
        public CurrentAccount() : base()
        {
            withdrawalLimit = 0.00;
        }
        public CurrentAccount(string accountNo, string accountTitle, string cnic, double balance, double withdrawalLimit)
            : base(accountNo, accountTitle, cnic, balance)
        {
            this.withdrawalLimit = withdrawalLimit;
        }

        // Virtual functions
        public override void deposit(double amount)
        {
            this.withdrawalLimit += 0.05 * amount;
            base.deposit(amount);
        }
        public override void withdrawal(double amount)
        {
            this.withdrawalLimit -= 0.05 * amount;
            base.withdrawal(amount);
        }
        public override string getAccountData()
        {
            string currentAccountDetails = base.getAccountData();
            currentAccountDetails += "Withdrawal Limit : " + this.withdrawalLimit;
            return currentAccountDetails;
        }
    }   // end of class

}   // end of namespace