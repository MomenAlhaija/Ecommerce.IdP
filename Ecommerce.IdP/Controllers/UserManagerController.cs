using Ecommerce.IdP.Enums;
using Ecommerce.IdP.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.IdP.Controllers;

[Authorize(Roles =nameof(RolesEnum.Admin))]
public class UserManagerController : Controller
{
    private readonly UserManager<EcommerceUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    public UserManagerController(UserManager<EcommerceUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public async Task<IActionResult> Index()
    {
        var users = await _userManager.Users.Select(user => new UserViewModel
        {
            Id=user.Id,
            Email = user.Email,
            UserName = user.UserName,
            Name = user.Name,
            PhoneNumber = user.PhoneNumber,
            DOB = user.DOB,
            Roles = _userManager.GetRolesAsync(user).Result
        }).ToListAsync();

        return View(users);
    }
    public async Task<IActionResult> ManageUserRoles(string userId)
    {
        var user =await _userManager.FindByIdAsync(userId);
        if (user is null)
            return NotFound(user);

        var roles =await _roleManager.Roles.ToListAsync();

        var manageUser = new ManageUserRolesVM
        {
            UserId = userId,
            UserName=user.UserName,
            Roles =roles.Select(role=>new RoleViewModel
            {
                Id=role.Id,
                Name=role.Name,
                IsSelected=_userManager.IsInRoleAsync(user,role.Name).Result
            }).ToList()
        };

        return View(manageUser);
    }
}
