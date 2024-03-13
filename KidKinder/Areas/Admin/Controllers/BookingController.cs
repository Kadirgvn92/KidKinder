using KidKinder.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KidKinder.Areas.Admin.Controllers;

[Area("Admin")]
[Route("Admin/[controller]/[action]/{id?}")]
public class BookingController : Controller
{
    private readonly Context _context;

    public BookingController(Context context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var values = _context.Bookings.Include(x => x.Class).ToList();
        return View(values);
    }
}
