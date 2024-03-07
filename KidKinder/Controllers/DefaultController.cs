using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KidKinder.Controllers;
[AllowAnonymous]
public class DefaultController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
