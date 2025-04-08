using Ecommerce.IdP.Enums;
using Ecommerce.IdP.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Ecommerce.IdP.Controllers
{
    [Authorize(Roles =nameof(RolesEnum.Admin))]
   
    public class RoleManagerController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleManagerController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<IActionResult> Index()
        {
            var roles = await _roleManager.Roles.ToListAsync();
            return View(roles);
        }
        [HttpPost]
        public async Task<IActionResult> AddRole([FromBody] CreateRole role)
        {

            try
            {
                if (!ModelState.IsValid)
                {
                    return Json(new { success = false, message = "Model Not Valied" });
                }
                else if(await _roleManager.RoleExistsAsync(role.RoleName.Trim()))
                {
                    return Json(new { success = false, message = "Role IS Already exists" });
                }
                await _roleManager.CreateAsync(new IdentityRole(role.RoleName.Trim()));
                return Json(new { success = true, message = "Role Added Sucessfully" });

            }
            catch (Exception ex)
            {

                return Json(new { success = false, message = ex.Message });
            }
        }
    }
}
