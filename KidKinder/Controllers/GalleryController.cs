using KidKinder.Entities;
using Microsoft.AspNetCore.Mvc;

namespace KidKinder.Controllers;
public class GalleryController : Controller
{
    private readonly Context _context;

    public GalleryController(Context context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var values = _context.Galleries.Where(x => x.Status == true).ToList();
        return View(values);
    }
    public IActionResult AddImage()
    {

    }
}
