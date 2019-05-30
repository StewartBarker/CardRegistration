using System;
using System.Security;

namespace CardRegistration.Models
{
    public class Card
    {
        public SecureString CardNumber { get; set; }
        public string Name { get; set; }        
        public DateTime ExpiryDate { get; set; }        
        public Address BillingAddress { get; set; }
    }
}
