using System;
using AcctMgr;
using System.Windows;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest_AcctMgr
{
    [TestClass]
    public class TestMathFuncitons
    {
        [TestMethod]
        public void TestAdd()
        {
            double expectedAmount = 175.00;
            double creditAmt = 50.00;
            MainWindow window = new MainWindow();
            double value = window.AddAmt(creditAmt);
            Assert.AreEqual(value, expectedAmount);
        }

        [TestMethod]
        public void TestSubtract()
        {
            double expectedAmount = 75.00;
            double debitAmt = 50.00;
            MainWindow window = new MainWindow();
            double value = window.SubAmt(debitAmt);
            Assert.AreEqual(value, expectedAmount);
        }
    }
}
