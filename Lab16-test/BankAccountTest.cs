using System;
using BankAccountNS;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BankTest
{
    [TestClass]
    public class BankAccountTest
    {
        [TestMethod]
        public void TestMethod1()
        {
        }

        // unit test code
        [TestMethod]
        public void Debit_WithValidAmount_UpdatesBalance()
        {
            // arrange
            double beginningBalance = 11.99;
            double debitAmount = 4.55;
            double expected = 7.44;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            // act
            account.Debit(debitAmount);

            // assert
            double actual = account.Balance;
            Assert.AreEqual(expected, actual, 0.001, "Account not debited correctly");
        }

        //unit test method
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Debit_WhenAmountIsLessThanZero_ShouldThrowArgumentOutOfRange()
        {
            // arrange
            double beginningBalance = 11.99;
            double debitAmount = -100.00;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            // act
            account.Debit(debitAmount);

            // assert is handled by ExpectedException
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Debit_WhenAmountIsMoreThanBalance_ShouldThrowArgumentOutOfRange()
        {
            // arrange
            double beginningBalance = 11.99;
            double debitAmount = 8000.00;
            BankAccount account = new BankAccount("Mr. Byran Walton", beginningBalance);

            // acting
            account.Debit(debitAmount);

            // assert is handled by ExpectedException
        }

        //unit test method
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Debit_WhenBalanceIsLessThanZero_ShouldThrowArgumentOutOfRange()
        {
            // arrange
            double beginningBalance = -100.0;
            double debitAmount = 10.00;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            // act
            account.Debit(debitAmount);

            // assert is handled by ExpectedException
        }
        //unit test method
        [TestMethod]
        public void Debit_WhenBalanceIsBigNumber_ShouldThrowArgumentOutOfRange()
        {
            // arrange
            double beginningBalance = 10e50;
            double debitAmount = 10.00;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            // act
            account.Debit(debitAmount);

            double actual = account.Balance;
            Assert.AreEqual(10e50-10, actual, 0.001, "Account not debited correctly");

        }

        //unit test method
        [TestMethod]
        public void Debit_WhenZeros_ShouldThrowArgumentOutOfRange()
        {
            // arrange
            double beginningBalance = 0.0;
            double debitAmount = 0.0;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            // act
            account.Debit(debitAmount);

            double actual = account.Balance;
            Assert.AreEqual(0, actual, 0.001, "Account not debited correctly");
        }
    }

}
