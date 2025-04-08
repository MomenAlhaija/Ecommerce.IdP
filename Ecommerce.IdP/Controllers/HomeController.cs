using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.IdP.Controllers;

public class HomeController : Controller
{
    public IActionResult Error(string errorId)
    {
        return View();
    }
}
