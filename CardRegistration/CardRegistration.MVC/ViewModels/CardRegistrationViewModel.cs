using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;

namespace CardRegistration.MVC.ViewModels
{
    public class CardRegistrationViewModel
    {
        [Display(Name="Card Number")]
        [Required]
        [StringLength(16, MinimumLength = 16, ErrorMessage = "Card number must be 16 characters")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Card number must contains only numbers")]
        [Remote("CardPassesLuhnCheck", "CardRegistration", HttpMethod = "POST", ErrorMessage = "Please enter a valid Card Number")]
        public string CardNumber { get; set; }

        [Required]
        public string Name { get; set; }

        public string ExpiryDateMonth { get; set; }
        public IEnumerable<SelectListItem> Months
        {
            get
            {      
                return Enumerable.Range(1, 12).Select(x => new SelectListItem { Value = x.ToString(), Text = x.ToString("00") });
            }
        }
        
        public string ExpiryDateYear { get; set; }
        public IEnumerable<SelectListItem> Years
        {
            get
            {
                return Enumerable.Range(DateTime.Now.Year, 20).Select(x => new SelectListItem { Value = x.ToString(), Text = x.ToString() });
            }
        }

        [Display(Name="Expiry Date")]
        [Remote("ExpiryDateIsValid", "CardRegistration", HttpMethod = "POST", ErrorMessage = "Please enter a valid Expiry Date")]
        public DateTime ExpiryDateMonthAndYear { get; set; }

        [Display(Name="Address Line 1")]
        [Required]
        public string AddressLine1 { get; set; }

        public string Town { get; set; }

        [Display(Name="Post Code")]
        [Required]
        public string PostCode { get; set; }       
    }
}