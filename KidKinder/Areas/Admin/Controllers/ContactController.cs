using KidKinder.Areas.Admin.Models;
using KidKinder.Entities;
using Microsoft.AspNetCore.Mvc;

namespace KidKinder.Areas.Admin.Controllers;
[Area("Admin")]
[Route("Admin/[controller]/[action]/{id?}")]
public class ContactController : Controller
{
    private readonly Context _context;

    public ContactController(Context context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var values = _context.GetInTouches.ToList();
        return View(values);
    }
    [HttpGet]
    public IActionResult UpdateContact(int id)
    {
        var values = _context.GetInTouches.FirstOrDefault(x => x.GetInTouchID == id);
        if(values != null) 
        {
            UpdateGetInTouchViewModel model = new UpdateGetInTouchViewModel
            {
                GetInTouchID = values.GetInTouchID,
                Address = values.Address,
                Mail = values.Mail,
                OpeningDays = values.OpeningDays,
                Phone = values.Phone,
                OpeningHours = values.OpeningHours
            };
            return View(model);
        }
        return View();
    }
    [HttpPost]
    public IActionResult UpdateContact(UpdateGetInTouchViewModel model)
    {
        var values = _context.GetInTouches.FirstOrDefault(x => x.GetInTouchID == model.GetInTouchID);

        values.Address = model.Address;
        values.Mail = model.Mail;
        values.OpeningDays = model.OpeningDays;
        values.Phone = model.Phone;
        values.OpeningHours = model.OpeningHours;

        _context.Update(values);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }
}
