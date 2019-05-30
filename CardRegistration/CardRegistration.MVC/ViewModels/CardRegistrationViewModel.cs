using CardRegistration.MVC.Attribute;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CardRegistration.MVC.ViewModels
{
    public class CardRegistrationViewModel
    {
        [Required]
        [StringLength(16, MinimumLength = 16, ErrorMessage = "Card number must be 16 characters")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Card number must contains only numbers")]
        [Remote("CardPassesLuhnCheck", "CardRegistration", HttpMethod = "POST", ErrorMessage = "Please enter a valid Card Number")]
        public string CardNumber { get; set; }
        [Required]
        public string Name { get; set; }
        public string ExpiryDateMonth { get; set; }
        public IEnumerable<SelectListItem> ExpiryMonths
        {
            get
            {               
                return DateTimeFormatInfo
                       .InvariantInfo
                       .MonthNames
                       .Select((monthName, index) => new SelectListItem
                       {
                           Value = (index + 1).ToString(),
                           Text = (index + 1).ToString("00")
                       });
            }
        }
        
        public string ExpiryDateYear { get; set; }
        public IEnumerable<SelectListItem> Years { get; set; }

        [Remote("ExpiryDateIsValid", "CardRegistration", HttpMethod = "POST", ErrorMessage = "Please enter a valid Expiry Date")]
        public string ExpiryDateMonthAndYear { get; set; }
        [Required]
        public string AddressLine1 { get; set; }
        public string Town { get; set; }
        [Required]
        public string PostCode { get; set; }       
    }
}