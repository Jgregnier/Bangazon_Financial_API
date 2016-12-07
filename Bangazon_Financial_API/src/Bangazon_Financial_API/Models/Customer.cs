using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bangazon_Financial_API.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId {get;set;}

        [Required]
        [StringLength(50)]
        public string FirstName {get;set;}

        [Required]
        [StringLength(50)]
        public string LastName {get;set;}

        public ICollection<PaymentType> PaymentTypes;

        public ICollection<Order> Orders;
    }
}
