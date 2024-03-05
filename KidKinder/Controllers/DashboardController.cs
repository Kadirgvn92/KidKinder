using KidKinder.Entities;
using Microsoft.AspNetCore.Mvc;

namespace KidKinder.Controllers;
public class DashboardController : Controller
{
    private readonly Context _context;

    public DashboardController(Context context)
    {
        _context = context;
    }

    public IActionResult Index()
    {

        return View();
    }
}
