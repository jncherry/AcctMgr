using System;
using AcctMgr;
using System.Windows;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest_AcctMgr
{
    [TestClass]
    public class TransactionTests
    {
        [TestMethod]
        public void TestTransID()
        {
            Transaction trans = new Transaction();
            int testID = 1234;
            trans.transID = testID;
            Assert.AreEqual(testID, trans.transID);
        }

        [TestMethod]
        public void TestTransDate()
        {
            Transaction trans = new Transaction();
            string testDate = "05/07/2015";
            trans.transDate = testDate;
            Assert.AreEqual(testDate, trans.transDate);
        }

        [TestMethod]
        public void TestTransType()
        {
            Transaction trans = new Transaction();
            string testTransType = "Debit";
            trans.transType = testTransType;
            Assert.AreEqual(testTransType, trans.transType);
        }

        [TestMethod]
        public void TestTransDesc()
        {
            Transaction trans = new Transaction();
            string testTransDesc = "Test Transaction";
            trans.transDesc = testTransDesc;
            Assert.AreEqual(testTransDesc, trans.transDesc);
        }

        [TestMethod]
        public void TestTransCleared()
        {
            Transaction trans = new Transaction();
            string testTransCleared = "Cleared";
            trans.transCleared = testTransCleared;
            Assert.AreEqual(testTransCleared, trans.transCleared);
        }

        [TestMethod]
        public void TestTransAmt()
        {
            Transaction trans = new Transaction();
            double testTransAmt = 245.50;
            trans.transAmt = testTransAmt;
            Assert.AreEqual(testTransAmt, trans.transAmt);
        }

        [TestMethod]
        public void TestDebitAmt()
        {
            Transaction trans = new Transaction();
            double testDebitAmt = 425.25;
            trans.debitAmt = testDebitAmt;
            Assert.AreEqual(testDebitAmt, trans.debitAmt);
        }

        [TestMethod]
        public void TestCreditAmt()
        {
            Transaction trans = new Transaction();
            double testCreditAmt = 157.75;
            trans.creditAmt = testCreditAmt;
            Assert.AreEqual(testCreditAmt, trans.creditAmt);
        }

        [TestMethod]
        public void TestAcctBal()
        {
            Transaction trans = new Transaction();
            double testAcctBal = 157.75;
            trans.acctBal = testAcctBal;
            Assert.AreEqual(testAcctBal, trans.acctBal);
        }
    }
}
