using System;
using System.Collections.Generic;
using System.Text;

namespace VP_Lab_2
{
    class Atm
    {
        // Data members
        string accountNo;
        string pin;

        // Properties
        public string AccountNo
        {
            set { this.accountNo = value; }
            get { return this.accountNo; }
        }
        public string Pin
        {
            set { this.pin = value; }
            get { return this.pin; }
        }

        // Constructors
        public Atm()
        {
            this.accountNo = "";
            this.pin = "";
        }
        public Atm(string accountNo, string pin)
        {
            this.accountNo = accountNo;
            this.pin = pin;
        }

    }   // end of class
}   // end of namespace