using Microsoft.AspNetCore.Mvc;

namespace KidKinder.Controllers;
public class DefaultController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
