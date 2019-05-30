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
            return View(new CardRegistrationViewModel());
        }

        [HttpPost]
        public ActionResult Index(CardRegistrationViewModel vm)
        {   
            return View(vm);           
        }

        [HttpPost]
        public ActionResult AddUpdateData(CardRegistrationViewModel vm)
        {
            //return Json(new { Success = true });
            if (!ModelState.IsValid)
            {
                return Json(new { success = false, errors = ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList() }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { success = true, errors = "" }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult CardPassesLuhnCheck(string CardNumber)
        {
            ICardValidationService cardValidationService = new CardValidationService(CardNumber);
            var result = cardValidationService.PassesLuhnTest();
            return Json(result);
        }

        [HttpPost]
        public JsonResult ExpiryDateIsValid(string month, string year)
        {
            return Json(true);
        }
    }
}