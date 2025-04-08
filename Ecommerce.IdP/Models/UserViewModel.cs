using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Identity;

namespace Ecommerce.IdP.Models;

public class UserViewModel
{
    public string Id { get; set; }
    public virtual string? PhoneNumber { get; set; }
    public virtual string? Email { get; set; }
    public virtual string? UserName { get; set; }
    public string? Name { get; set; }
    public DateTime DOB { get; set; }

    public IEnumerable<string>? Roles { get; set; }
}
