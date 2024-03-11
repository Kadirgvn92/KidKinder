using Microsoft.AspNetCore.Mvc;

namespace KidKinder.Controllers;
public class ContactController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
