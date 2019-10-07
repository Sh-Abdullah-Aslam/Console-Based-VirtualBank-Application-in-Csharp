using System;
using System.Collections.Generic;
using System.Text;

namespace VP_Lab_2
{
    class SavingAccount : Account
    {
        // Data-members
        private double profitPercentage;

        // Properties
        public double ProfitPercentage
        {
            set { this.profitPercentage = value; }
            get { return this.profitPercentage; }
        }

        // Constructors
        public SavingAccount() : base()
        {
            profitPercentage = 0.00;
        }
        public SavingAccount(string accountNo, string accountTitle, string cnic, double balance, double profitPercentage)
            : base(accountNo, accountTitle, cnic, balance)
        {
            this.profitPercentage = profitPercentage;
        }

        // Virtual functions
        public override void deposit(double amount)
        {
            this.profitPercentage += 0.02 * amount;
            base.deposit(amount);
        }
        public override void withdrawal(double amount)
        {
            this.profitPercentage -= 0.02 * amount;
            if (this.profitPercentage < 0)
                this.profitPercentage = 0;
            base.withdrawal(amount);
        }
        public override string getAccountData()
        {
            string savingAccountDetails = base.getAccountData();
            savingAccountDetails += "Profit Percentage : " + this.profitPercentage;
            return savingAccountDetails;
        }

    }   // end of class

}   // end of namespace
