using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce.IdP.Models;

public class EcommerceUser:IdentityUser
{
    [Required]
    [DataType(DataType.Text)]
    [DisplayName("Full Name")]
    public string Name { get; set; }

    [Required]
    [DataType(DataType.DateTime)]
    [DisplayName("Birth Date")]
    public DateTime DOB { get; set; }


}
