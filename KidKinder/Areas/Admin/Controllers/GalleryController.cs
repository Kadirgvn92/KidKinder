using KidKinder.Entities;
using Microsoft.AspNetCore.Mvc;

namespace KidKinder.Areas.Admin.Controllers;

[Area("Admin")]
[Route("Admin/[controller]/[action]/{id?}")]
public class GalleryController : Controller
{
    private readonly Context _context;

    public GalleryController(Context context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var values = _context.Galleries.ToList();
        return View(values);
    }
    public IActionResult MakeItTrue(int id)
    {
        var values = _context.Galleries.FirstOrDefault(x => x.GalleryID == id);
        values.Status = true;
        _context.Update(values);
        _context.SaveChanges();
        return RedirectToAction("Index", "Gallery");

    }
    public IActionResult MakeItFalse(int id)
    {
        var values = _context.Galleries.FirstOrDefault(x => x.GalleryID == id);
        values.Status = false;
        _context.Update(values);
        _context.SaveChanges();
        return RedirectToAction("Index", "Gallery");
    }
}
