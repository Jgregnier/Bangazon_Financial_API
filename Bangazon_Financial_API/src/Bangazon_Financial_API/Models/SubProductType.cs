using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bangazon_Financial_API.Models
{
  public class SubProductType
  {
    [Key]
    public int SubProductTypeId {get; set;}
    [Required]
    [StringLength(100)]
    public string Name {get; set;}
    [Required]
    [StringLength(255)]
    public string Description {get; set;}
    [Required]
    public int ProductTypeId {get; set;}
    public ProductType ProductType;
    public ICollection<Product> Products; 
    }
}
