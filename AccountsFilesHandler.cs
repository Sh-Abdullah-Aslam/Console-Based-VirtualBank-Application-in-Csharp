using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace VP_Lab_2
{
    class AccountsFilesHandler
    {
        // Data Members
        ArrayList allCurrentAccountsArrayList;
        List<SavingAccount> allSavingAccountsArrayList;
        ArrayList allTransations;
        ArrayList allAtmCards;

        //Properties
        public ArrayList AllCurrentAccountsArrayList
        {
            set { this.allCurrentAccountsArrayList = value; }
            get { return this.allCurrentAccountsArrayList; }
        }
        public List<SavingAccount> AllSavingAccountsList
        {
            set { this.allSavingAccountsArrayList = value; }
            get { return this.allSavingAccountsArrayList; }
        }
        public ArrayList AllTransations
        {
            set { this.allTransations = value; }
            get { return this.allTransations; }
        }
        public ArrayList AllAtmCards
        {
            set { this.allAtmCards = value; }
            get { return this.allAtmCards; }
        }

        // Constructors
        public AccountsFilesHandler()
        {
            this.allCurrentAccountsArrayList = new ArrayList();
            this.allSavingAccountsArrayList = new List<SavingAccount>();
            this.allTransations = new ArrayList();
            this.allAtmCards = new ArrayList();

            this.allCurrentAccountsArrayList = this.readAllCurrentAccounts();
            this.allSavingAccountsArrayList = this.readAllSavingAccounts();
            this.allTransations = this.readAllTransactionsAsArrayList();
            this.allAtmCards = this.readAllAtmDetails();
        }

        // Reading accounts files
        public ArrayList readAllCurrentAccounts()
        {
            ArrayList arrayListToReturnCurrentAccounts = new ArrayList();

            StreamReader currentAccountFile = new StreamReader("CurrentAccounts.txt");

            string accountNo = "";
            string accountTitle = "";
            string cnic = "";
            double balance = 0.00;
            double withdrawalLimit = 0.00;

            while (!(currentAccountFile.EndOfStream))
            {
                accountNo = currentAccountFile.ReadLine();
                accountTitle = currentAccountFile.ReadLine();
                cnic = currentAccountFile.ReadLine();
                balance = double.Parse(currentAccountFile.ReadLine());
                withdrawalLimit = double.Parse(currentAccountFile.ReadLine());

                arrayListToReturnCurrentAccounts.Add(new CurrentAccount(accountNo, accountTitle, cnic, balance, withdrawalLimit));
            }

            currentAccountFile.Close();

            return arrayListToReturnCurrentAccounts;
        }
        public List<SavingAccount> readAllSavingAccounts()
        {
            List<SavingAccount> listToReturnSavingAccounts = new List<SavingAccount>();

            StreamReader savingAccountFile = new StreamReader("SavingAccounts.txt");

            string accountNo = "";
            string accountTitle = "";
            string cnic = "";
            double balance = 0.00;
            double profitPercentage = 0.00;

            while (!(savingAccountFile.EndOfStream))
            {
                accountNo = savingAccountFile.ReadLine();
                accountTitle = savingAccountFile.ReadLine();
                cnic = savingAccountFile.ReadLine();
                balance = double.Parse(savingAccountFile.ReadLine());
                profitPercentage = double.Parse(savingAccountFile.ReadLine());

                listToReturnSavingAccounts.Add(new SavingAccount(accountNo, accountTitle, cnic, balance, profitPercentage));
            }

            savingAccountFile.Close();

            return listToReturnSavingAccounts;
        }
        public ArrayList readAllTransactionsAsArrayList()
        {
            ArrayList arrayListForTodaysTransactions = new ArrayList();

            StreamReader transactionsFile = new StreamReader("Transactions.txt");

            string accountNo = "";
            double balance = 0.00;
            char accountType = ' ';
            string dateOfTodayAsString = "";

            while (!transactionsFile.EndOfStream)
            {
                accountNo = transactionsFile.ReadLine();
                balance = double.Parse(transactionsFile.ReadLine());
                accountType = transactionsFile.ReadLine()[0];
                dateOfTodayAsString = transactionsFile.ReadLine();

                arrayListForTodaysTransactions.Add(new Transaction(accountNo, balance, accountType, DateTime.Parse(dateOfTodayAsString)));
            }

            transactionsFile.Close();

            return arrayListForTodaysTransactions;
        }
        public ArrayList readAllAtmDetails()
        {
            ArrayList atmArrayListToReturn = new ArrayList();

            StreamReader atmDetailsFile = new StreamReader("AtmDetails.txt");

            while(!atmDetailsFile.EndOfStream)
            {
                string accountNo = atmDetailsFile.ReadLine();
                string pin = atmDetailsFile.ReadLine();

                atmArrayListToReturn.Add(new Atm(accountNo, pin));
            }

            atmDetailsFile.Close();

            return atmArrayListToReturn;
        }

        // Writing accounts files
        public void writeBackAllCurrentAccountsToFile()
        {
            StreamWriter currentAccountsFile = new StreamWriter("CurrentAccounts.txt");

            for (int index = 0; index < allCurrentAccountsArrayList.Count; index ++)
            {
                currentAccountsFile.WriteLine((allCurrentAccountsArrayList[index] as CurrentAccount).AccountNo);
                currentAccountsFile.WriteLine((allCurrentAccountsArrayList[index] as CurrentAccount).AccountTitle);
                currentAccountsFile.WriteLine((allCurrentAccountsArrayList[index] as CurrentAccount).Cnic);
                currentAccountsFile.WriteLine((allCurrentAccountsArrayList[index] as CurrentAccount).Balance);
                currentAccountsFile.WriteLine((allCurrentAccountsArrayList[index] as CurrentAccount).WithdrawalLimit);
            }

            currentAccountsFile.Flush();
            currentAccountsFile.Dispose();
        }
        public void writeBackAllSavingAccountsToFile()
        {
            StreamWriter savingAccountsFile = new StreamWriter("SavingAccounts.txt");

            for (int index = 0; index < allSavingAccountsArrayList.Count; index++)
            {
                savingAccountsFile.WriteLine((allSavingAccountsArrayList[index] as SavingAccount).AccountNo);
                savingAccountsFile.WriteLine((allSavingAccountsArrayList[index] as SavingAccount).AccountTitle);
                savingAccountsFile.WriteLine((allSavingAccountsArrayList[index] as SavingAccount).Cnic);
                savingAccountsFile.WriteLine((allSavingAccountsArrayList[index] as SavingAccount).Balance);
                savingAccountsFile.WriteLine((allSavingAccountsArrayList[index] as SavingAccount).ProfitPercentage);
            }

            savingAccountsFile.Flush();
            savingAccountsFile.Dispose();
        }
        public void writeBackAllTransactionsToFile()
        {
            StreamWriter transactionFile = new StreamWriter("Transactions.txt");
            for (int index = 0; index < allTransations.Count; index++)
            {
                Transaction transactionToWrite = allTransations[index] as Transaction;
                transactionFile.WriteLine(transactionToWrite.AccountNo);
                transactionFile.WriteLine(transactionToWrite.Amount);
                transactionFile.WriteLine(transactionToWrite.AccountType);
                transactionFile.WriteLine(transactionToWrite.Today);
                transactionToWrite.getTransactionInfo();
            }

            transactionFile.Flush();
            transactionFile.Dispose();
        }
        public void writeBackAllAtmDetailsToFile()
        {
            StreamWriter atmDetailsFile = new StreamWriter("AtmDetails.txt");

            for (int index = 0; index < allAtmCards.Count; index++)
            {
                atmDetailsFile.WriteLine((allAtmCards[index] as Atm).AccountNo);
                atmDetailsFile.WriteLine((allAtmCards[index] as Atm).Pin);
            }

            atmDetailsFile.Flush();
            atmDetailsFile.Dispose();
        }

        // Generating transaction reports
        public void generateTransactionReport(Transaction transactionToGenerateItsReport, double balanceLeft)
        {
            StreamWriter transactionReportFile = new StreamWriter("TransactionReports/" + transactionToGenerateItsReport.AccountNo + "-" + transactionToGenerateItsReport.Today.ToString().Substring(0, 9).Replace("/", "_") + transactionToGenerateItsReport.Today.ToString().Substring(9).Replace(":", "-") + ".txt");

            transactionReportFile.WriteLine("Account No : " + "****-****-****-*" + transactionToGenerateItsReport.AccountNo);
            transactionReportFile.WriteLine("Account Type : " + ((transactionToGenerateItsReport.AccountType == 'C') ? "Current" : "Saving"));
            transactionReportFile.WriteLine("Transaction Amount : " + transactionToGenerateItsReport.Amount);
            transactionReportFile.WriteLine("Remaining Balance : " + balanceLeft);
            transactionReportFile.WriteLine("Date and Time of Transaction : " + transactionToGenerateItsReport.Today.ToString());

            transactionReportFile.Flush();
            transactionReportFile.Dispose();
        }

    }   // End of class

}   // End of namespace
