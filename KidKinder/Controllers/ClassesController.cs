using KidKinder.Entities;
using Microsoft.AspNetCore.Mvc;

namespace KidKinder.Controllers;
public class ClassesController : Controller
{
    private readonly Context _context;

    public ClassesController(Context context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var values = _context.KidClasses.ToList();
        return View(values);
    }
}
