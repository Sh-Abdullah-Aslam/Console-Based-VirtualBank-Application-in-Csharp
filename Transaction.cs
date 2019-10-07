using System;
using System.Collections.Generic;
using System.Text;

namespace VP_Lab_2
{
    class Transaction
    {
        string accountNo;
        double amount;
        char accountType;
        DateTime dateOfTransaction;

        // Default arguments parametrized constructor
        public Transaction() { }
        public Transaction(string accountNo, double amount, char accountType, DateTime dateTime)
        {
            this.accountNo = accountNo;
            this.amount = amount;
            this.accountType = accountType;
            this.dateOfTransaction = dateTime;
        }

        // Properties
        public string AccountNo
        {
            set { this.accountNo = value; }
            get { return this.accountNo; }
        }
        public double Amount
        {
            set { this.amount = value; }
            get { return this.amount; }
        }
        public char AccountType
        {
            set { this.accountType = value; }
            get { return this.accountType; }
        }
        public DateTime Today
        {
            set { this.dateOfTransaction = value; }
            get { return this.dateOfTransaction; }
        }

        public void getTransactionInfo()
        {
            string info = "Account No : " + this.accountNo + "\n";
            info += "Amount : " + this.amount + "\n";
            info += "Account type : " + this.accountType + "\n";
            info += "Date Of Transaction : " + this.dateOfTransaction.ToString() + "\n";
        }

    }   // end of class

}   // end of namesapce