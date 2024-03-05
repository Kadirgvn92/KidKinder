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
        var classes = _context.KidClasses.Count();
        ViewBag.Classes = classes;
        var teacher = _context.Teachers.Count();
        ViewBag.Teachers = teacher;
        return View();
    }
}
