using KidKinder.Entities;
using Microsoft.AspNetCore.Mvc;

namespace KidKinder.Areas.Admin.Controllers;

[Area("Admin")]
[Route("Admin/[controller]/[action]/{id?}")]
public class TestimonialController : Controller
{
    private readonly Context _context;

    public TestimonialController(Context context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var values = _context.Testimonials.ToList();
        return View(values);
    }
}
