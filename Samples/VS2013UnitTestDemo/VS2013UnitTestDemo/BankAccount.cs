using System;

namespace BankAccountNS
{
    /// <summary> 
    /// Bank Account demo class. 
    /// </summary> 
    public class BankAccount
    {
        private string m_customerName;

        private double m_balance;

        private bool m_frozen = false;
        //if constructor is private,no object can be new outside the class.
        /*
        //private BankAccount()
        //{
        //}
        */
        public BankAccount()
        { }

        public BankAccount(string customerName, double balance)
        {
            m_customerName = customerName;
            m_balance = balance;
        }

        public string CustomerName
        {
            get { return m_customerName; }
        }

        public double Balance
        {
            get { return m_balance; }
        }

        public void Debit(double amount)
        {
            if (m_frozen)
            {
                throw new Exception("Account frozen");
            }

            if (amount > m_balance)
            {
                throw new ArgumentOutOfRangeException("amount");
            }

            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException("amount");
            }

            //m_balance += amount; // intentionally incorrect code
            m_balance -= amount; 
        }

        public void SetFrozenTrue()
        { m_frozen = true; }

        public void Credit(double amount)
        {
            if (m_frozen)
            {
                throw new Exception("Account frozen");
            }

            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException("amount");
            }

            m_balance += amount;
        }
        /*
        public void Add(int a)
        {}
        */
    }
}
