using KidKinder.Entities;
using Microsoft.AspNetCore.Mvc;

namespace KidKinder.Areas.Admin.Controllers;

[Area("Admin")]
[Route("Admin/[controller]/[action]/{id?}")]
public class MessageController : Controller
{
    private readonly Context _context;

    public MessageController(Context context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var values = _context.Contacts.Where(x => x.IsRead == false).ToList();
        return View(values);
    }
    public IActionResult ReadMessage(int id)
    {
        var values = _context.Contacts.FirstOrDefault(x => x.ContactID == id);
        values.IsRead = true;
        _context.SaveChanges();
        return RedirectToAction("Index");
    }
    public IActionResult DoneMessage()
    {
        var values = _context.Contacts.Where(x => x.IsRead == true).ToList();
        return View(values);
    }
    public IActionResult DeleteMessage(int id)
    {
        var values = _context.Contacts.FirstOrDefault(x => x.ContactID == id);
        _context.Remove(values);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }
}
