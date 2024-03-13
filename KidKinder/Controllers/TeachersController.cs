using KidKinder.Entities;
using Microsoft.AspNetCore.Mvc;

namespace KidKinder.Controllers;
public class TeachersController : Controller
{
    private readonly Context _context;

    public TeachersController(Context context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var values = _context.Teachers.ToList();
        return View(values);
    }
}
