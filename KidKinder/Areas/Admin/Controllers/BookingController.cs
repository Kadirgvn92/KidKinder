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
        var values = _context.Bookings.Include(x => x.Class).Where(x => x.IsCompleted == false).ToList();
        return View(values);
    }
    public IActionResult CompleteBooking(int id)
    {
        var values = _context.Bookings.FirstOrDefault(x => x.IsCompleted == false);
        values.IsCompleted = true;
        _context.SaveChanges();
        return RedirectToAction("Index");
    }
    public IActionResult CompletedBooking()
    {
        var values = _context.Bookings.Include(x => x.Class).Where( x => x.IsCompleted == true).ToList();    
        return View(values);
    }
    public IActionResult DeleteBooking(int id)
    {
        var values = _context.Bookings.FirstOrDefault(x => x.BookingID == id);
        _context.Remove(values);
        _context.SaveChanges(); 
        return RedirectToAction("CompletedBooking");
    }
}
