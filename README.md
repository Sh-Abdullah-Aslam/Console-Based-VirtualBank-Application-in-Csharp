# Console based banking system ( Version 1.0 )

```
This was my fifth semester's Lab Task at Bahria University Islamabad assigned by Prof. Ghulam Ali Mirza in the course of Visual Programming.
```

## Key Features

```
  01. Has seperate interfaces for Manager and Account Holder.
  02. Incorporates both types of accounts (Current and Saving).
  03. Follows object oriented concepts.
  04. Uses datastructures to store data during the execution of program.
  05. Filing is used to store and retrive data at end and start of the program respectively.
  06. Manager can perform all operations (Create, Read, Update and Delete on both Current and Saving accounts).
  07. An account holder can only access their account.
  08. An account holder can have an ATM facility if they want.
  09. Atm will allow account holder to withdraw and deposit facilty on their account.
  10. A transaction report is generated for every transaction made by a user
```
  
## Explaination of classes made

```
  01. Account                 An abstract class that is inherited by both type of accounts.
  02. Current Account         Inherited from the Account class with implementation of virtual functions.
  03. Saving Account          Inherited from the Account class with implementation of virtual functions.
  04. Transaction             A standalone class to store transactions ($50000 or 5 transactions are allowed per day).
  05. ATM                     A standalone class to store info of users' ATM pins.
  06. Accounts Files Handler  Class composed in AccountManager to read and store data to files using data structures.
  07. Input Output Handler    Class that is used for console based interaction with the person interacting.
  08. Account Manager         Class with the implementation of all the functionality
  09. Program                 Usual C# Program.cs class that contains the Main function
```

## Explaination of files used

~~~
  01. CurrentAccounts.txt       Stores CurrentAccounts info              (AccountNo, Name, Cnic, Balance, WithdrawalLimit)
  02. SavingAccounts.txt        Storer SavingAccounts info               (AccountNo, Name, Cnic, Balance, ProfitPercentage)
  03. AtmDetails.txt            Stores ATM cards details                 (AccountNo, Pin)
  04. Transactions.txt          Stores the transactions details          (AccountNo, Amount, AccountType, DateOfTransaction)
  05. TransactionReports/*.txt  The report that is generated after every transaction
~~~

## Prerequisites to setup the system (These will be removed in the next update)

  - You'll need to comment the last 4 lines of code in the constructor of AccountsFilesHandler class when you run it for the first time.
  - You'll need to create a folder named TransactionReports inside the bin > Debug > [only folder inside this file] > [create the folder here]

### Explaination of name of files generated as Transaction Reports (001-9_30_2019 6-13-25 PM.txt)
  
  - First is the account number
  - Followed by a hyphen
  - Then comes the date of transaction with underscores seperating them
  - Followed by a space
  - Then comes time seperated using hyphens
  - Followed by a space
  - And the name ends with the Time Meridian

# Open for reuse (with or without) editing but cite my work and fork me on Github [VirtualBank](https://github.com/Sh-Abdullah-Aslam/Console-Based-VirtualBank-Application-in-Csharp).
