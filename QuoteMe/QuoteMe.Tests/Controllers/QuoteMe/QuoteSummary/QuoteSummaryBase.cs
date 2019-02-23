using System;
using System.Linq;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuoteMe.MVC.Controllers;
using QuoteMe.MVC.Models;
using QuoteMe.MVC.Services.FinancePlanCalculator;

namespace QuoteMe.Tests.Controllers.QuoteMe.QuoteSummary
{
    public abstract class QuoteSummaryBase
    {
        private Quote _quote;
        private ViewResult _result;
        private FinancePlan _financePlan;

        private int _expectedNumOfRepayments;
        private decimal _expectedOutstandingPayment;
        private decimal _expectedAmountDueEachMonth;

        [TestInitialize]
        public void SetupTest()
        {
            var controller = new QuoteMeController(new InterestFreeFinancePlanCalculator());
            _quote = GetQuote();
            _result = controller.QuoteSummary(_quote) as ViewResult;
            _financePlan = (FinancePlan) _result.ViewData.Model;
            _expectedNumOfRepayments = _quote.NumOfRepaymentYears * 12;
            _expectedOutstandingPayment = _quote.VehiclePrice - _quote.DepositAmount;
            _expectedAmountDueEachMonth = _expectedOutstandingPayment / _expectedNumOfRepayments;
        }

        [TestMethod]
        public void Test_Correct_View_Returned()
        {
            Assert.AreEqual("FinancePlan", _result.ViewName);
        }

        [TestMethod]
        public void Test_Correct_Quote_Returned()
        {
            Assert.AreEqual(_quote, _financePlan.Quote);
        }

        [TestMethod]
        public void Test_Correct_Outstanding_Payment()
        {
            var expectedOutstandingPayment = _quote.VehiclePrice - _quote.DepositAmount;
            Assert.AreEqual(expectedOutstandingPayment, _financePlan.OutstandingPayment);
        }

        [TestMethod]
        public void Test_Correct_Outstanding_Payment_With_Fees()
        {
            var expectedOutstandingPaymentWithFees = _expectedOutstandingPayment + _quote.ArrangementFee + _quote.CompletionFee;
            Assert.AreEqual(expectedOutstandingPaymentWithFees, _financePlan.OutstandingPaymentWithFees);
        }

        [TestMethod]
        public void Test_Correct_Number_Of_Repayment_Months()
        {
            Assert.AreEqual(_expectedNumOfRepayments, _financePlan.MonthlyRepayments.Count);
        }

        [TestMethod]
        public void Test_Every_Repayment_Is_First_Monday_Of_Month()
        {
            var expectedRepaymentDay = DayOfWeek.Monday;
            Assert.IsTrue(_financePlan.MonthlyRepayments.All(x => x.DateDue.DayOfWeek == expectedRepaymentDay && x.DateDue.Day <= 7));
        }

        [TestMethod]
        public void Test_First_Repayment_Amount_Is_Correct()
        {
            var expectedFirstRepayment = _expectedAmountDueEachMonth + _quote.ArrangementFee;
            var firstRepayment = _financePlan.MonthlyRepayments.First();
            Assert.AreEqual(expectedFirstRepayment, firstRepayment.AmountDue);
        }

        [TestMethod]
        public void Test_Last_Repayment_Amount_Is_Correct()
        {
            var expectedLastRepayment = _expectedAmountDueEachMonth + _quote.CompletionFee;
            var lastRepayment = _financePlan.MonthlyRepayments.Last();
            Assert.AreEqual(expectedLastRepayment, lastRepayment.AmountDue);
        }

        [TestMethod]
        public void Test_All_Other_Repayment_Amounts_Are_Correct()
        {
            var allOtherRepayments = _financePlan.MonthlyRepayments.Skip(1).Take(_expectedNumOfRepayments - 2);
            Assert.IsTrue(allOtherRepayments.All(x => x.AmountDue == _expectedAmountDueEachMonth));
        }

        protected abstract Quote GetQuote();
    }
}
