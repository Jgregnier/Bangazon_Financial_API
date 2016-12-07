using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bangazon_Financial_API.Models
{
  public class ProductType
  {
    [Key]
    public int ProductTypeId {get; set;}
    [Required]
    public string Name {get; set;}
    public ICollection<SubProductType> SubProductTypes; 
    }
}
