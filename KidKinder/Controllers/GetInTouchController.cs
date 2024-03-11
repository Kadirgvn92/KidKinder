using KidKinder.Entities;
using KidKinder.Models;
using Microsoft.AspNetCore.Mvc;

namespace KidKinder.Controllers;
public class GetInTouchController : Controller
{
    private readonly Context _context;

    public GetInTouchController(Context context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Index(SendMessageViewModel model)
    {
        if (ModelState.IsValid)
        {
            _context.Contacts.Add(new Contact()
            {
                Message = model.Message,
                Mail = model.Mail,
                Name = model.Name,
                Subject = model.Subject,
                SendDate = Convert.ToDateTime(DateTime.Now.ToShortDateString())
            });
            return RedirectToAction("Index", "Default");
        }
        return View();
    }
}
