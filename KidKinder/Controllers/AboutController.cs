using Microsoft.AspNetCore.Mvc;

namespace KidKinder.Controllers;
public class AboutController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
