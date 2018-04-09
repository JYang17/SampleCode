using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using BankAccountNS;

namespace BankAccountNS.Tests
{
    [TestClass()]
    public class BankAccountTests
    {
        [TestMethod()]
        [ExpectedException(typeof(Exception))]
        public void DebitTest()
        {
            BankAccount account1 = new BankAccount();
            account1.SetFrozenTrue();
            account1.Debit(0);
            
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void DebitTest1()
        {
            BankAccount account2 = new BankAccount("k",10);
            account2.Debit(11);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void DebitTest2()
        {
            BankAccount account1 = new BankAccount();
            account1.Debit(-2);
        }

        [TestMethod()]
        [ExpectedException(typeof(Exception))]
        public void CreditTest()
        {
            BankAccount account1 = new BankAccount();
            account1.SetFrozenTrue();
            account1.Credit(0);
        }

        [TestMethod()]
        public void CustomerName_GetMethod()
        {
            BankAccount ba = new BankAccount("a",1);
            Assert.IsTrue(ba.CustomerName == "a");
        }
    }
}

namespace BankAccountTest
{
    [TestClass]
    public class BankAccountTests
    {
        // unit test code
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Debit_WithValidAmount_UpdatesBalance()
        {
            // arrange
            double beginningBalance = 11.99;
            double debitAmount = 4.55;
            double expected = 7.44;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);
            

            // act
            account.Debit(debitAmount);
            account.Credit(0);
            string cname = account.CustomerName;

            
            
            // assert
            double actual = account.Balance;
            Assert.AreEqual(expected, actual, 0.001, "Account not debited correctly");

            BankAccount account1 = new BankAccount();
            account1.Credit(-1);
        }

    }
}
