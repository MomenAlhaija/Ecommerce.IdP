namespace Ecommerce.IdP.Models;

public class ManageUserRolesVM
{
    public string UserId { get; set; }
    public string UserName { get; set; }
    public List<RoleViewModel> Roles { get; set; }
}
