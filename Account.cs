using System;
using System.Collections.Generic;
using System.Text;

namespace VP_Lab_2
{
    abstract class Account
    {
        // Data-members
        protected string accountNo;
        protected string accountTitle;
        protected string cnic;
        protected double balance;

        // Properties
        public string AccountNo
        {
            set { this.accountNo = value; }
            get { return this.accountNo; }
        }
        public string AccountTitle
        {
            set { this.accountTitle = value; }
            get { return this.accountTitle; }
        }
        public string Cnic
        {
            set { this.cnic = value; }
            get { return this.cnic; }
        }
        public double Balance
        {
            set { this.balance = value; }
            get { return this.balance; }
        }

        // Constructors
        public Account()
        {
            this.accountNo = "";
            this.accountTitle = "";
            this.cnic = "";
            this.balance = 0.00;
        }
        public Account(string accountNo, string accountTitle, string cnic, double balance)
        {
            this.accountNo = accountNo;
            this.accountTitle = accountTitle;
            this.cnic = cnic;
            this.balance = balance;
        }

        // Virtual functions
        virtual public void withdrawal(double amount)
        {
            this.balance -= amount;
        }
        virtual public void deposit(double amount)
        {
            this.balance += amount;
        }
        virtual public string getAccountData()
        {
            string accountDetails = "";

            accountDetails += "Account No : " + this.accountNo + "\n";
            accountDetails += "Account Title : " + this.accountTitle + "\n";
            accountDetails += "Cnic : " + this.cnic + "\n";
            accountDetails += "Balance : " + this.balance + "\n";

            return accountDetails;
        }
    }   // end of class
}   // end of namespace