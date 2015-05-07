using System;
using System.Windows;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest_AcctMgr
{
    [TestClass]
    public class TestAddFunciton_ValidAmount
    {
        [TestMethod]
        public void TestAdd()
        {
            double expectedAmount = 175.00;
            double creditAmt = 50.00;
            AcctMgr.MainWindow window = new AcctMgr.MainWindow();
            double value = window.AddAmt(creditAmt);
            Assert.AreEqual(value, expectedAmount);
        }
    }
}
