using CardRegistration.MVC.Attribute;
using CardRegistration.MVC.ViewModels;
using CardRegistration.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CardRegistration.MVC.Controllers
{
    public class CardRegistrationController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.Success = false;
            return View(new CardRegistrationViewModel());
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Index(CardRegistrationViewModel vm)
        {
            ViewBag.Success = false;
            CardRegistrationViewModel vmWithHiddenCardNumber = vm;
            if (ModelState.IsValid)
            {
                ViewBag.Success = true;
                vmWithHiddenCardNumber = new CardRegistrationViewModel
                {
                    Name = vm.Name,
                    CardNumber = $"**** **** **** {vm.CardNumber.Substring(vm.CardNumber.Length - 4, 4)}",
                    ExpiryDateMonthAndYear = vm.ExpiryDateMonthAndYear,
                    ExpiryDateMonth = vm.ExpiryDateMonth,
                    ExpiryDateYear = vm.ExpiryDateYear,
                    AddressLine1 = vm.AddressLine1,
                    Town = vm.Town,
                    PostCode = vm.PostCode
                };                 
            }            
            return View(vmWithHiddenCardNumber);           
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult IsModelStateValidAjax(CardRegistrationViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { success = false}, JsonRequestBehavior.AllowGet);
            }
            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }
                
        [HttpPost]
        public JsonResult CardPassesLuhnCheck(string CardNumber)
        {
            ICardValidationService cardValidationService = new CardValidationService(CardNumber);
            var result = cardValidationService.PassesLuhnTest();
            return Json(result);
        }
                
        [HttpPost]
        public JsonResult ExpiryDateIsValid(DateTime ExpiryDateMonthAndYear)
        {
            try
            {
                    var validExpiryDate = Convert.ToDateTime(ExpiryDateMonthAndYear);
                if (validExpiryDate <= DateTime.Today || (validExpiryDate.Year - DateTime.Today.Year > 20))
                {
                    return Json(false);
                }
                return Json(true);
            }
            catch(Exception ex)
            {
                return Json(false);
            }
        }
    }
}