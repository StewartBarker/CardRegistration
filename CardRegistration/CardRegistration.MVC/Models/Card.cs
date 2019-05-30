using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Web;

namespace CardRegistration.MVC.Models
{
    public class Card
    {
        public SecureString CardNumber { get; set; }
        public string Name { get; set; }
        public DateTime ExpiryDate { get; set; }
        public Address BillingAddress { get; set; }
    }
}