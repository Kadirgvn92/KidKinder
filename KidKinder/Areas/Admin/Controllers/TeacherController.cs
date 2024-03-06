using KidKinder.Entities;
using Microsoft.AspNetCore.Mvc;

namespace KidKinder.Controllers;

[Area("Admin")]
[Route("Admin/[controller]/[action]/{id?}")]
public class TeacherController : Controller
{
    private readonly Context _context;

    public TeacherController(Context context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var values = _context.Teachers.ToList();
        return View(values);
    }
}
