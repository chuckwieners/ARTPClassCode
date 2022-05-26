using System;
using Bank;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BankTests
{
    #region Unit Test Notes
    /*
     *  The minimum requirements for a test class are the following:
     *  The [TestClass] attribute is required in the Microsoft unit testing framework for managed code 
     *  for any class that contains unit test methods that you want to run in Test Explorer.
     *  
     *  Each test method that you want Test Explorer to run must have the [TestMethod] attribute.
     *  
     *  You can have other classes in a unit test project that do not have the [TestClass] attribute, 
     *  and you can have other methods in test classes that do not have the [TestMethod] attribute. You can use 
     *  these other classes and methods in your test methods.
     */
    #endregion

    [TestClass]
    public class BankAccountTests
    {
        // unit test code
        /*
         * Setup notes:
         * The method is rather simple. We set up a new BankAccount object with a beginning balance and 
         * then withdraw a valid amount. We use the Microsoft unit test framework for managed code AreEqual 
         * method to verify that the ending balance is what we expect.
         */


        #region Test Method Requirements
        //The method must be decorated with the [TestMethod] attribute.
        //The method must return void.
        //The method cannot have parameters. (all values are declared in the body of the method for the test)
        #endregion

        [TestMethod]
        public void Debit_WithValidAmount_UpdatesBalance()
        {
            //arrange (declare and set values)
            double beginningBalance = 11.99;
            double debitAmount = 4.55;
            //value expected in the return
            double expected = 7.44;
            BankAccount account = new BankAccount("Mr. Jeffrey DeMaranville", beginningBalance);

            //act (call the method)
            account.Debit(debitAmount);

            //Assert (insure that the method does what it is supposed to do)
            //create a variable that holds the result of the calculation performed
            double actual = account.Balance;

            //then assert expected value vs the actual value
            //              expected, actual, delta (maximum variance), error message if test fails
            Assert.AreEqual(expected, actual, 0.001, "Account not debited correctly");
        }
        //To Run this test:
        //Menu>Test>Windows>TestExplorer>RunAllTests
    }
}
