using KidKinder.Entities;
using KidKinder.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace KidKinder.Controllers;
[AllowAnonymous]
public class DefaultController : Controller
{
    private readonly Context _context;

    public DefaultController(Context context)
    {
        _context = context;
    }
    [HttpGet]
    public IActionResult Index()
    {
        List<SelectListItem> classes = (from x in _context.KidClasses.ToList()
                                        select new SelectListItem
                                        {
                                            Text = x.Name,
                                            Value = x.KidClassID.ToString()
                                        }).ToList();
        ViewBag.v = classes;
        return View();
    }
    [HttpPost]
    public IActionResult Index(CreateBookingViewModel model)
    {

        Booking book = new Booking
        {
            Name = model.Name,
            ClassID = model.KidClassID,
            Mail = model.Mail,
            Phone = model.Phone,
        };

        _context.Bookings.Add(book);
        _context.SaveChanges();
        return RedirectToAction("Index","Default");
    }
}
