using CardRegistration.MVC.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardRegistration.MVC.Tests.Controllers
{
    [TestClass]
    public class CardRegistrationTests
    {
        [TestMethod]
        public void MonthsDropDownDisplaysCorrectMonths()
        {           
            CardRegistrationViewModel vm = new CardRegistrationViewModel();
            var months = vm.Months;
            Assert.AreEqual(12, vm.Months.Count());
        }

        [TestMethod]
        public void YearsDropDownDisplaysCorrectYears()
        {
            CardRegistrationViewModel vm = new CardRegistrationViewModel();
            var years = vm.Years;
        }

    }
}
