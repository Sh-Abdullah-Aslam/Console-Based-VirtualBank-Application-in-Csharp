using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace VP_Lab_2
{
    class InputOutputHandler
    {
        // Constructor
        public InputOutputHandler(){}

        // Get new account data and return as the object of the particular class
        public CurrentAccount getCurrentAccountDetailsFromUser()
        {
            Console.Write("Account No : ");
            string accountNo = Console.ReadLine();
            while (accountNo.Length < 3)
            {
                Console.Write("Re-enter Account No with length of 3 characters or more : ");
                accountNo = Console.ReadLine();
            }

            Console.Write("Account Title : ");
            string accountTitle = Console.ReadLine();

            while (!accountTitle.Contains(" "))
            {
                Console.Write("Please enter a full-name : ");
            }

            Console.Write("Cnic : ");
            string cnic = Console.ReadLine();

        ReCheck:
            int count = 0;
            for (int i = 0; i < cnic.Length; i++)
                if (cnic[i] == '-')
                    count++;

            if (count < 2)
            {
                Console.Write("Please Re-enter cnic : ");
                cnic = Console.ReadLine();
                goto ReCheck;
            }


            Console.Write("Balance : ");
            string balanceInputAsString = Console.ReadLine();

            while (!balanceInputAsString.Contains(".") || balanceInputAsString[0] == '-')
            {
                Console.Write("Re-enter your Balance in float positive value : ");
                balanceInputAsString = Console.ReadLine();
            }
            double balance = double.Parse(balanceInputAsString);

            Console.Write("Withdrawal-Limit : ");
            string withdrawalLimitAsString = Console.ReadLine();

            while (!withdrawalLimitAsString.Contains(".") || withdrawalLimitAsString[0] == '-')
            {
                Console.Write("Re-enter your Withdrawal-Limit in float positive value : ");
                balanceInputAsString = Console.ReadLine();
            }
            double withdrawalLimit = double.Parse(withdrawalLimitAsString);
            //Console.WriteLine("\nCurrent account with AccountNo : '"+ accountNo +"'  created successfully\n");

            return new CurrentAccount(accountNo, accountTitle, cnic, balance, withdrawalLimit);
        }
        public SavingAccount getSavingAccountDetailsFromUser()
        {

            Console.Write("Account No : ");
            string accountNo = Console.ReadLine();
            while (accountNo.Length < 3)
            {
                Console.Write("Re-enter Account No with length of 3 characters or more : ");
                accountNo = Console.ReadLine();
            }

            Console.Write("Account Title : ");
            string accountTitle = Console.ReadLine();

            while (!accountTitle.Contains(" "))
            {
                Console.Write("Please enter a full-name : ");
            }

            Console.Write("Cnic : ");
            string cnic = Console.ReadLine();

        ReCheck:
            int count = 0;
            for (int i = 0; i < cnic.Length; i++)
                if (cnic[i] == '-')
                    count++;

            if (count < 2)
            {
                Console.Write("Please Re-enter cnic : ");
                cnic = Console.ReadLine();
                goto ReCheck;
            }

            Console.Write("Balance : ");
            string balanceInputAsString = Console.ReadLine();

            while (!balanceInputAsString.Contains(".") || balanceInputAsString[0] == '-')
            {
                Console.Write("Re-enter your Balance in float positive value : ");
                balanceInputAsString = Console.ReadLine();
            }
            double balance = double.Parse(balanceInputAsString);

            Console.Write("Profit Percentage : ");
            string profitPercentageInputAsString = Console.ReadLine();

            while (!profitPercentageInputAsString.Contains(".") || profitPercentageInputAsString[0] == '-')
            {
                Console.Write("Re-enter your Balance in float positive value : ");
                profitPercentageInputAsString = Console.ReadLine();
            }
            double profitPercentage = double.Parse(profitPercentageInputAsString);

            return new SavingAccount(accountNo, accountTitle, cnic, balance, profitPercentage);
        }

        // Ask user for ATM
        public bool wantAnAtm()
        {
            Console.Write("\nDo you want ATM facility with your account ? (y/n) : ");
            char choice = Console.ReadLine()[0];
            if (choice == 'y' || choice == 'Y')
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public string getAtmPinFromUser()
        {
            Console.Write("Enter a 4 digit PIN for your account : ");
            string pin = this.getPassword();

            while(pin.Length != 4)
            {
                Console.Write("Please enter a 4  PIN : ");
                pin = this.getPassword();
            }
            return pin;
        }

        // The function used below is taken from:
            // --https://stackoverflow.com/questions/3404421/password-masking-console-application?rq=1 
        private string getPassword()
        {
            string pass = "";
            do
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                // Backspace Should Not Work
                if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                {
                    pass += key.KeyChar;
                    Console.Write("*");
                }
                else
                {
                    if (key.Key == ConsoleKey.Backspace && pass.Length > 0)
                    {
                        pass = pass.Substring(0, (pass.Length - 1));
                        Console.Write("\b \b");
                    }
                    else if (key.Key == ConsoleKey.Enter)
                    {
                        break;
                    }
                }
            } while (true);
            return pass;
        }

        // Get an account no from user as input
        public string getAccountNoFromUser()
        {
            Console.Write("Enter the account no : ");
            string accountNo = Console.ReadLine();

            while (accountNo.Length < 3)
            {
                accountNo = Console.ReadLine();
            }

            return accountNo;
        }

        // Get an amount to deposit from user as input
        public double getAmountToDepositFromUser()
        {
            Console.Write("Enter the amount to deposit : ");
            string amountInString = Console.ReadLine();

            while(amountInString.StartsWith("-"))
            {
                Console.Write("Enter a positive amount to deposit : ");
                amountInString = Console.ReadLine();
            }

            return double.Parse(amountInString);
        }

        public double getAmountToWithdrawFromUser(double allowedAmount, double balance)
        {
            Console.WriteLine("Maximum amount allowed to withdraw : " + allowedAmount.ToString());
            Console.WriteLine("Total Balance : " + balance.ToString() + "\n");

            Console.Write("Enter the amount to withdraw : ");
            string withdrawAmountInString = Console.ReadLine();

            while (withdrawAmountInString.StartsWith("-") || double.Parse(withdrawAmountInString) > allowedAmount || double.Parse(withdrawAmountInString) > balance)
            {
                Console.Write("Enter a positive amount that is allowed to withdraw : ");
                withdrawAmountInString = Console.ReadLine();
            }

            return double.Parse(withdrawAmountInString);
        }

        // Print threshold met
        public void cantWithdrawToday(double amount)
        {
            Console.WriteLine("You cant withdraw : " + amount.ToString() + " today.");
        }

        // Update menus
        public SavingAccount printUpdateSavingAccountMenu(SavingAccount accountToUpdate)
        {
            Console.WriteLine("##### Account Info #####\n");
            this.printOneSavingAccount(accountToUpdate);

            Console.WriteLine("Press 1 to update Account No");
            Console.WriteLine("Press 2 to update Account Title");
            Console.WriteLine("Press 3 to update Cnic");
            Console.WriteLine("Press 4 to update Balance");
            Console.WriteLine("Press 5 to update Withdrawal Limit");
            Console.WriteLine("Press 0 to Exit");

            Console.Write("Your Choice : ");
            char choice = Console.ReadLine()[0];

            while (!(choice >= '0' && choice <= '5'))
            {
                Console.Write("Re-enter your choice between 0 and 5 : ");
                choice = Console.ReadLine()[0];
            }

            switch (choice)
            {
                case '1':
                    Console.Write("Enter new account no : ");
                    accountToUpdate.AccountNo = Console.ReadLine();
                    break;
                case '2':
                    Console.Write("Enter new title : ");
                    accountToUpdate.AccountTitle = Console.ReadLine();
                    break;
                case '3':
                    Console.Write("Enter new Cnic : ");
                    accountToUpdate.Cnic = Console.ReadLine();
                    break;
                case '4':
                    Console.Write("Enter new balance : ");
                    accountToUpdate.Balance = double.Parse(Console.ReadLine());
                    break;
                case '5':
                    Console.Write("Enter new profit percentage : ");
                    accountToUpdate.ProfitPercentage = double.Parse(Console.ReadLine());
                    break;
                default:
                    Console.WriteLine("No changes have been made!");
                    break;
            };
            return accountToUpdate;
        }
        public CurrentAccount printUpdateCurrentAccountMenu(CurrentAccount accountToUpdate)
        {
            Console.WriteLine("##### Account Info #####\n");
            this.printOneCurrentAccount(accountToUpdate);

            Console.WriteLine("Press 1 to update Account No");
            Console.WriteLine("Press 2 to update Account Title");
            Console.WriteLine("Press 3 to update Cnic");
            Console.WriteLine("Press 4 to update Balance");
            Console.WriteLine("Press 5 to update Profit Percentage");
            Console.WriteLine("Press 0 to Exit");

            Console.Write("Your Choice : ");
            char choice = Console.ReadLine()[0];

            while (!(choice >= '0' && choice <= '5'))
            {
                Console.Write("Re-enter your choice between 0 and 5 : ");
                choice = Console.ReadLine()[0];
            }

            switch (choice)
            {
                case '1':
                    Console.Write("Enter new account no : ");
                    accountToUpdate.AccountNo = Console.ReadLine();
                    break;
                case '2':
                    Console.Write("Enter new title : ");
                    accountToUpdate.AccountTitle = Console.ReadLine();
                    break;
                case '3':
                    Console.Write("Enter new Cnic : ");
                    accountToUpdate.Cnic = Console.ReadLine();
                    break;
                case '4':
                    Console.Write("Enter new balance : ");
                    accountToUpdate.Balance = double.Parse(Console.ReadLine());
                    break;
                case '5':
                    Console.Write("Enter new Profit Percentage : ");
                    accountToUpdate.WithdrawalLimit = double.Parse(Console.ReadLine());
                    break;
                default:
                    Console.WriteLine("No changes have been made!");
                    break;
            };
            return accountToUpdate;
        }

        // Display an account of a certain type that is passed as argument
        public void printOneCurrentAccount(CurrentAccount currentAccountToPrint)
        {
            Console.WriteLine(currentAccountToPrint.getAccountData() + "\n");
        }
        public void printOneSavingAccount(SavingAccount savingAccountToPrint)
        {
            Console.WriteLine(savingAccountToPrint.getAccountData() + "\n");
        }

        // Display all accounts of a certain type
        public void printAllCurrentAccounts(ArrayList allCurrentAccounts)
        {
            Console.WriteLine("------------------------------");
            Console.WriteLine("------ Current Accounts ------");
            Console.WriteLine("------------------------------");

            for (int index = 0; index < allCurrentAccounts.Count; index++)
            {
                this.printOneCurrentAccount(allCurrentAccounts[index] as CurrentAccount);
            }
        }
        public void printAllSavingAccounts(ArrayList allSavingAccounts)
        {
            Console.WriteLine("------------------------------");
            Console.WriteLine("------- Saving Accounts ------");
            Console.WriteLine("------------------------------");

            for (int index = 0; index < allSavingAccounts.Count; index++)
            {
                this.printOneCurrentAccount(allSavingAccounts[index] as CurrentAccount);
            }
        }

        // Print error message for not found
        public void printNotFoundCurrentAccount(string accountNo)
        {
            Console.WriteLine("Found no Current Account with Account Number : " + accountNo);
        }
        public void printNotFoundSavingAccount(string accountNo)
        {
            Console.WriteLine("Found no Saving Account with Account Number : " + accountNo);
        }
        
        // Get type of account from user
        public char selectAccountType()
        {
            Console.Write("Select Account type from (c/s) : ");
            char choice = Console.ReadLine()[0];

            while(choice != 'c' && choice != 's')
            {
                Console.Write("Select a valid option from (c/s) : ");
                choice = Console.ReadLine()[0];
            }

            return choice;
        }

        // Check if the interactor is user or manager
        public void printInterfaceOnTheBasisOfUser()
        {
            Console.WriteLine("##### MY VITRUAL BANK #####\n");
            Console.WriteLine("Press 1 for Account Holder");
            Console.WriteLine("Press 2 for Account Manager");
            Console.WriteLine("Press 0 to Exit");

            Console.Write("\nEnter your choice : ");
            char choice = Console.ReadLine()[0];

            switch(choice)
            {
                case '0':
                    Environment.Exit(0);
                    break;
                case '1':
                    this.printAccountHolderInterface();
                    break;
                case '2':
                    this.printManagerInterface();
                    break;
            };
        }

        // Interface for user
        public void printAccountHolderInterface()
        {
            AccountManager userInteracting = new AccountManager();
            string accountNo = this.getAccountNoFromUser();
            string pin = "";

            if (this.selectAccountType() =='c')
            {
                if (userInteracting.getCurrentAccountIndex(accountNo) == -1)
                {
                    Console.WriteLine("Current Account with AccountNo '" + accountNo + "' does not exist");
                    Environment.Exit(0);
                }

                if (!userInteracting.hasAtm(accountNo))
                {
                    Console.WriteLine("You dont an atm card registered");
                    Console.Write("Register for ATM now (y/n) : ");

                    char choice = Console.ReadLine()[0];

                    if (choice == 'y' || choice == 'Y')
                    {
                        pin = this.getAtmPinFromUser();
                        userInteracting.AccountsData.AllAtmCards.Add(new Atm(accountNo, pin));
                    }
                    else
                    {
                        Console.WriteLine("Bye! Come back when you want or have an atm card");
                        Environment.Exit(0);
                    }
                }

                CurrentAccount accountInfoOfTheUserWhoLoggedIn = userInteracting.AccountsData.AllCurrentAccountsArrayList[userInteracting.getCurrentAccountIndex(accountNo)] as CurrentAccount;

                do
                {
                    Console.Clear();

                    Console.WriteLine("##### My Virtual Bank #####");
                    Console.WriteLine("Press 0 to exit");
                    Console.WriteLine("Press 1 to display account info");
                    Console.WriteLine("Press 2 to deposit an amount");
                    Console.WriteLine("Press 3 to withdraw an amount");

                    Console.Write("\nEnter your choice : ");
                    char choice = Console.ReadLine()[0];

                    switch (choice)
                    {
                        case '0':
                            userInteracting.writeBackAllFiles();
                            Environment.Exit(0);
                            break;
                        case '1':
                            this.printOneCurrentAccount(accountInfoOfTheUserWhoLoggedIn);
                            break;
                        case '2':
                            pin = this.getAtmPinFromUser();
                            if (userInteracting.verifyCredentials(accountInfoOfTheUserWhoLoggedIn.AccountNo, pin))
                            {
                                userInteracting.makeDepositToCurrentAccount(accountNo);
                            }
                            else
                            {
                                Console.WriteLine("You entered incorrect pin");
                            }
                            break;
                        case '3':
                            pin = this.getAtmPinFromUser();
                            if (userInteracting.verifyCredentials(accountInfoOfTheUserWhoLoggedIn.AccountNo, pin))
                            {
                                userInteracting.makeTransactionFromCurrentAccount(accountNo);
                            }
                            else
                            {
                                Console.WriteLine("You entered incorrect pin");
                            }
                            break;
                        default:
                            break;
                    }
                } while (askIfUserWantsToContinue());
            }
            else
            {
                if(userInteracting.getSavingAccountIndex(accountNo) == -1)
                {
                    Console.WriteLine("Saving Account with AccountNo '" + accountNo + "' does not exist");
                    Environment.Exit(0);
                }

                if (!userInteracting.hasAtm(accountNo))
                {
                    Console.WriteLine("You dont an atm card registered");
                    Console.Write("Register for ATM now (y/n) : ");

                    char choice = Console.ReadLine()[0];

                    if (choice == 'y' || choice == 'Y')
                    {
                        pin = this.getAtmPinFromUser();
                        userInteracting.AccountsData.AllAtmCards.Add(new Atm(accountNo, pin));
                    }
                    else
                    {
                        Console.WriteLine("Bye! Come back when you want or have an atm card");
                        Environment.Exit(0);
                    }
                }

                SavingAccount accountInfoOfTheUserWhoLoggedIn = userInteracting.AccountsData.AllSavingAccountsList[userInteracting.getCurrentAccountIndex(accountNo)];

                do
                {
                    Console.Clear();

                    Console.WriteLine("Press 0 to exit");
                    Console.WriteLine("Press 1 to get account details");
                    Console.WriteLine("Press 2 to deposit an amount");
                    Console.WriteLine("Press 3 to withdraw an amount");

                    char choice = Console.ReadLine()[0];

                    switch (choice)
                    {
                        case '0':
                            userInteracting.writeBackAllFiles();
                            Environment.Exit(0);
                            break;
                        case '1':
                            this.printOneSavingAccount(accountInfoOfTheUserWhoLoggedIn);
                            break;

                        case '2':
                            pin = this.getAtmPinFromUser();
                            if (userInteracting.verifyCredentials(accountInfoOfTheUserWhoLoggedIn.AccountNo, pin))
                            {
                                userInteracting.makeDepositToSavingAccount(accountNo);
                            }
                            else
                            {
                                Console.WriteLine("You entered incorrect pin");
                            }
                            break;
                        case '3':
                            pin = this.getAtmPinFromUser();
                            if (userInteracting.verifyCredentials(accountInfoOfTheUserWhoLoggedIn.AccountNo, pin))
                            {
                                userInteracting.makeTransactionFromSavingAccount(accountNo);
                            }
                            else
                            {
                                Console.WriteLine("You entered incorrect pin");
                            }
                            break;
                        default:
                            break;
                    }

                } while (askIfUserWantsToContinue());
            }
        }

        // Interface for manager
        public void printManagerInterface()
        {
            AccountManager manager = new AccountManager();

            do
            {
                Console.Clear();

                Console.WriteLine("##### MY VITRUAL BANK #####\n");
                Console.WriteLine("Press 1 to Create a new Current Account");
                Console.WriteLine("Press 2 to Create a new Saving Account");
                Console.WriteLine("Press 3 to Display a Current Account");
                Console.WriteLine("Press 4 to Display a Saving Account");
                Console.WriteLine("Press 5 to Update a Current Account");
                Console.WriteLine("Press 6 to Update a Saving Account");
                Console.WriteLine("Press 7 to Delete a Current Account");
                Console.WriteLine("Press 8 to Delete a Saving Account");
                Console.WriteLine("Press a to Make a deposit to Current Account");
                Console.WriteLine("Press b to Make a deposit to Saving Account");
                Console.WriteLine("Press c to withdraw from Current Account");
                Console.WriteLine("Press d to withdraw from Saving Account");
                Console.WriteLine("Press 0 to EXIT");

                Console.Write("\nYour choice : ");
                char choice = Console.ReadLine()[0];

                while (!(choice >= '0' && choice <= '8') && !(choice >= 'a' && choice <= 'd'))
                {
                    Console.Write("\nEnter a valid choice : ");
                    choice = Console.ReadLine()[0];
                }

                Console.WriteLine("");

                switch (choice)
                {
                    case '0':
                        goto endingManagerActivities;
                        // No need to break because the above statement itself will take the control outside of this scope
                    case '1':
                        manager.addACurrentAccount();
                        break;
                    case '2':
                        manager.addASavingAccount();
                        break;
                    case '3':
                        manager.readACurrentAccountsDetails();
                        break;
                    case '4':
                        manager.readASavingAccountsDetails();
                        break;
                    case '5':
                        manager.updateCurrentAccount();
                        break;
                    case '6':
                        manager.updateSavingAccount();
                        break;
                    case '7':
                        manager.deleteACurrentAccount();
                        break;
                    case '8':
                        manager.deleteASavingAccount();
                        break;
                    case 'a':
                        manager.makeDepositToCurrentAccount();
                        break;
                    case 'b':
                        manager.makeDepositToSavingAccount();
                        break;
                    case 'c':
                        manager.makeTransactionFromCurrentAccount();
                        break;
                    case 'd':
                        manager.makeTransactionFromSavingAccount();
                        break;

                };
            } while (askIfUserWantsToContinue());

        endingManagerActivities:
            manager.writeBackAllFiles();
        }
        public bool askIfUserWantsToContinue()
        {
            Console.Write("\n\nDo you want to exit the system ? (y/n) : ");
            char choice = Console.ReadLine()[0];
            
            return (choice == 'Y' || choice == 'y') ? false : true;
        }
    }   // End of class

}   // End of namespace