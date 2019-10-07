using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace VP_Lab_2
{
    class AccountManager
    {
        // Data members
        AccountsFilesHandler accountsData;
        InputOutputHandler IO_Handler;

        public AccountsFilesHandler AccountsData
        {
            set { this.accountsData = value; }
            get { return this.accountsData; }
        }

        // Constructor
        public AccountManager()
        {
            accountsData = new AccountsFilesHandler();
            IO_Handler = new InputOutputHandler();
        }

        // Check if a user has ATM facility enabled
        public bool hasAtm(string accountNo)
        {
            for (int index = 0; index < accountsData.AllAtmCards.Count; index++)
            {
                if((accountsData.AllAtmCards[index] as Atm).AccountNo == accountNo)
                {
                    return true;
                }
            }
            return false;
        }

        // Verify the credentials entered by the ATM user
        public bool verifyCredentials(string accountNo, string pin)
        {
            foreach (Atm atmToCheck in this.accountsData.AllAtmCards)
            {
                if (atmToCheck.AccountNo == accountNo && atmToCheck.Pin == pin)
                {
                    return true;
                }
            }
            return false;
        }

        // Creation of Accounts
        public void addACurrentAccount()
        {
            CurrentAccount newCurrentAccountCreated = IO_Handler.getCurrentAccountDetailsFromUser();
            accountsData.AllCurrentAccountsArrayList.Add(newCurrentAccountCreated);
            if (IO_Handler.wantAnAtm())
            {
                string pin = IO_Handler.getAtmPinFromUser();
                accountsData.AllAtmCards.Add(new Atm(newCurrentAccountCreated.AccountNo, pin));
            }
        }
        public void addASavingAccount()
        {
            SavingAccount newSavingAccountCreated = IO_Handler.getSavingAccountDetailsFromUser();
            accountsData.AllSavingAccountsList.Add(newSavingAccountCreated);
            if (IO_Handler.wantAnAtm())
            {
                string pin = IO_Handler.getAtmPinFromUser();
                accountsData.AllAtmCards.Add(new Atm(newSavingAccountCreated.AccountNo, pin));
            }
        }

        // Reading a sigle account
        public void readACurrentAccountsDetails()
        {
            string accountNo = IO_Handler.getAccountNoFromUser();
            int indexOfCurrentAccountInADT = this.getCurrentAccountIndex(accountNo);

            if (indexOfCurrentAccountInADT != -1)
            {
                IO_Handler.printOneCurrentAccount(accountsData.AllCurrentAccountsArrayList[indexOfCurrentAccountInADT] as CurrentAccount);
            }
            else
            {
                IO_Handler.printNotFoundCurrentAccount(accountNo);
            }
        }
        public void readASavingAccountsDetails()
        {
            string accountNo = IO_Handler.getAccountNoFromUser();
            int indexOfSavingAccountInADT = this.getSavingAccountIndex(accountNo);

            if (indexOfSavingAccountInADT != -1)
            {
                IO_Handler.printOneSavingAccount(accountsData.AllSavingAccountsList[indexOfSavingAccountInADT] as SavingAccount);
            }
            else
            {
                IO_Handler.printNotFoundSavingAccount(accountNo);
            }
        }

        // Updation of Accounts
        public void updateCurrentAccount()
        {
            string accountNoToUpdateItsDetails = IO_Handler.getAccountNoFromUser();
            int indexOfCurrentAccountToUpdate = getCurrentAccountIndex(accountNoToUpdateItsDetails);

            if (indexOfCurrentAccountToUpdate != -1)
            {
                CurrentAccount accountToUpdate = accountsData.AllCurrentAccountsArrayList[indexOfCurrentAccountToUpdate] as CurrentAccount;
                accountsData.AllCurrentAccountsArrayList[indexOfCurrentAccountToUpdate] = IO_Handler.printUpdateCurrentAccountMenu(accountToUpdate);
            }
            else
            {
                IO_Handler.printNotFoundCurrentAccount(accountNoToUpdateItsDetails);
            }
        }
        public void updateSavingAccount()
        {
            string accountNoToUpdateItsDetails = IO_Handler.getAccountNoFromUser();
            int indexOfSavingAccountToUpdate = getCurrentAccountIndex(accountNoToUpdateItsDetails);

            if (indexOfSavingAccountToUpdate != -1)
            {
                SavingAccount accountToUpdate = accountsData.AllSavingAccountsList[indexOfSavingAccountToUpdate] as SavingAccount;
                accountsData.AllSavingAccountsList[indexOfSavingAccountToUpdate] = IO_Handler.printUpdateSavingAccountMenu(accountToUpdate);
            }
            else
            {
                IO_Handler.printNotFoundSavingAccount(accountNoToUpdateItsDetails);
            }
        }

        // Delete Accounts
        public void deleteACurrentAccount()
        {
            string accountNo = IO_Handler.getAccountNoFromUser();
            int indexOfCurrentAccountInADT = this.getCurrentAccountIndex(accountNo);

            if (indexOfCurrentAccountInADT != -1)
            {
                accountsData.AllSavingAccountsList.RemoveAt(indexOfCurrentAccountInADT);
                Console.WriteLine("Deletion of Saving Account with Account No : " + accountNo + " successful");
            }
            else
            {
                IO_Handler.printNotFoundCurrentAccount(accountNo);
            }
        }
        public void deleteASavingAccount()
        {
            string accountNo = IO_Handler.getAccountNoFromUser();
            int indexOfSavingAccountInADT = this.getSavingAccountIndex(accountNo);

            if (indexOfSavingAccountInADT != -1)
            {
                accountsData.AllSavingAccountsList.RemoveAt(indexOfSavingAccountInADT);
                Console.WriteLine("Deletion of Saving Account with Account No : " + accountNo + " successful");
            }
            else
            {
                IO_Handler.printNotFoundSavingAccount(accountNo);
            }
        }

        // Searching for records in CurrentAccount ArrayList
        public int getCurrentAccountIndex(string accountNo)
        {
            for (int index = 0; index < accountsData.AllCurrentAccountsArrayList.Count; index++)
            {
                if ((accountsData.AllCurrentAccountsArrayList[index] as CurrentAccount).AccountNo == accountNo)
                {
                    return index;
                }
            }
            return -1;
        }

        // Searching for records in List<SavingAccount>
        public int getSavingAccountIndex(string accountNo)
        {
            for (int index = 0; index < accountsData.AllSavingAccountsList.Count; index++)
            {
                if ((accountsData.AllSavingAccountsList[index] as SavingAccount).AccountNo == accountNo)
                {
                    return index;
                }
            }
            return -1;
        }

        // Selecting only todays records 
        public ArrayList getTodaysTransactions()
        {
            ArrayList todaysTransactions = new ArrayList();
            for (int index = 0; index < accountsData.AllTransations.Count; index++)
            {
                if ((accountsData.AllTransations[index] as Transaction).Today.ToString().StartsWith(DateTime.Now.ToString().Substring(0, 9)))
                    todaysTransactions.Add(accountsData.AllTransations[index]);
            }
            return todaysTransactions;
        }

        // Checking if the transaction can be performed or not
        public bool isTransactionsThresholdMetForAnAccount(string accountNo, double amount)
        {
            double sum = amount;
            int noOfTransactionsMadeToday = 0;
            ArrayList todaysTransactions = this.getTodaysTransactions();

            for (int index = 0; index < todaysTransactions.Count; index++)
            {
                if ((todaysTransactions[index] as Transaction).AccountNo == accountNo)
                {
                    sum += (todaysTransactions[index] as Transaction).Amount;
                    noOfTransactionsMadeToday++;
                    if (sum >= 50000.0 || noOfTransactionsMadeToday >= 5)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        // Make deposit to account
        public void makeDepositToCurrentAccount(string accountNo = "")
        {
            if (accountNo == "")
            {
                InputOutputHandler IO_Handler = new InputOutputHandler();
                accountNo = IO_Handler.getAccountNoFromUser();
            }
            int indexOfCurrentAccountInADT = this.getCurrentAccountIndex(accountNo);

            if (indexOfCurrentAccountInADT != -1)
            {
                double depositAmount = IO_Handler.getAmountToDepositFromUser();
                (accountsData.AllCurrentAccountsArrayList[indexOfCurrentAccountInADT] as CurrentAccount).deposit(depositAmount);
            }
            else
            {
                IO_Handler.printNotFoundCurrentAccount(accountNo);
            }
        }
        public void makeDepositToSavingAccount(string accountNo ="")
        {
            if (accountNo == "")
            {
                InputOutputHandler IO_Handler = new InputOutputHandler();
                accountNo = IO_Handler.getAccountNoFromUser();
            }
            int indexOfSavingAccountInADT = this.getSavingAccountIndex(accountNo);

            if (indexOfSavingAccountInADT != -1)
            {
                double depositAmount = IO_Handler.getAmountToDepositFromUser();
                (accountsData.AllSavingAccountsList[indexOfSavingAccountInADT] as SavingAccount).deposit(depositAmount);
            }
            else
            {
                IO_Handler.printNotFoundSavingAccount(accountNo);
            }
        }

        // Make transactions from accounts
        public void makeTransactionFromCurrentAccount(string accountNo = "")
        {
            if (accountNo == "")
            {
                InputOutputHandler IO_Handler = new InputOutputHandler();
                accountNo = IO_Handler.getAccountNoFromUser();
            }
            int indexOfCurrentAccountInADT = this.getCurrentAccountIndex(accountNo);

            if (indexOfCurrentAccountInADT != -1)
            {
                CurrentAccount currentAccountToMakeTransactionOn = accountsData.AllCurrentAccountsArrayList[indexOfCurrentAccountInADT] as CurrentAccount;
                double withdrawAmount = IO_Handler.getAmountToWithdrawFromUser(currentAccountToMakeTransactionOn.WithdrawalLimit, currentAccountToMakeTransactionOn.Balance);
                
                if (!isTransactionsThresholdMetForAnAccount(currentAccountToMakeTransactionOn.AccountNo, withdrawAmount)) 
                {
                    (accountsData.AllCurrentAccountsArrayList[indexOfCurrentAccountInADT] as CurrentAccount).withdrawal(withdrawAmount);
                    Transaction transaction = new Transaction(currentAccountToMakeTransactionOn.AccountNo, withdrawAmount, 'C', DateTime.Now);
                    accountsData.AllTransations.Add(transaction);
                    accountsData.generateTransactionReport(transaction, (accountsData.AllCurrentAccountsArrayList[indexOfCurrentAccountInADT] as CurrentAccount).Balance);
                }
                else
                {
                    IO_Handler.cantWithdrawToday(withdrawAmount);
                }
            }
            else
            {
                IO_Handler.printNotFoundCurrentAccount(accountNo);
            }
        }
        public void makeTransactionFromSavingAccount(string accountNo = "")
        {
            if (accountNo == "")
            {
                InputOutputHandler IO_Handler = new InputOutputHandler();
                accountNo = IO_Handler.getAccountNoFromUser();
            }
            int indexOfSavingAccountInADT = this.getSavingAccountIndex(accountNo);

            if (indexOfSavingAccountInADT != -1)
            {
                SavingAccount savingAccountToMakeTransactionOn = accountsData.AllSavingAccountsList[indexOfSavingAccountInADT] as SavingAccount;
                double withdrawAmount = IO_Handler.getAmountToWithdrawFromUser(savingAccountToMakeTransactionOn.Balance, savingAccountToMakeTransactionOn.Balance);

                if (!isTransactionsThresholdMetForAnAccount(savingAccountToMakeTransactionOn.AccountNo, withdrawAmount))
                {
                    (accountsData.AllSavingAccountsList[indexOfSavingAccountInADT] as SavingAccount).withdrawal(withdrawAmount);
                    Transaction transaction = new Transaction(savingAccountToMakeTransactionOn.AccountNo, withdrawAmount, 'S', DateTime.Now);
                    accountsData.AllTransations.Add(transaction);
                    accountsData.generateTransactionReport(transaction, (accountsData.AllSavingAccountsList[indexOfSavingAccountInADT] as SavingAccount).Balance);
                }
                else
                {
                    IO_Handler.cantWithdrawToday(withdrawAmount);
                }
                
                
            }
            else
            {
                IO_Handler.printNotFoundSavingAccount(accountNo);
            }
        }

        // Writing back all the files as the destructor is not working
        public void writeBackAllFiles()
        {
            accountsData.writeBackAllTransactionsToFile();
            accountsData.writeBackAllSavingAccountsToFile();
            accountsData.writeBackAllCurrentAccountsToFile();
            accountsData.writeBackAllAtmDetailsToFile();
        }

        // Destructor
        ~AccountManager()
        {
            accountsData.writeBackAllTransactionsToFile();
            accountsData.writeBackAllSavingAccountsToFile();
            accountsData.writeBackAllCurrentAccountsToFile();
            accountsData.writeBackAllAtmDetailsToFile();
        }

    }    // End of class

}   // End of namespace