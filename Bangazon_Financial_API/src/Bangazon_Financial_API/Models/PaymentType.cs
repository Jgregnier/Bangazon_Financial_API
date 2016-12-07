using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bangazon_Financial_API.Models
{
    public class PaymentType
    {
        [Key]
        public int PaymentTypeId {get;set;}
        
        [Required]
        public int CustomerId {get;set;}

        public Customer Customer {get;set;}

        [Required]
        public string CardNumber {get;set;}

        [Required]
        [StringLength(25)]
        public string Processor {get;set;}

        [Required]
        public string ExpirationDate {get;set;}

        [Required]
        [StringLength(80)]
        public string StreetAddress {get;set;}

        [Required]
        [StringLength(50)]
        public string City {get;set;}

        [Required]
        [StringLength(2)]
        public string State {get;set;}

        [Required]
        [Range(00001, 99999)]
        public int ZipCode {get;set;}

        [Required]
        [StringLength(50)]
        public string FirstName {get;set;}

        [Required]
        [StringLength(50)]
        public string LastName {get;set;}
        public ICollection<Order> Orders;

    }
}