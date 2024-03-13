using KidKinder.Areas.Admin.Models;
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
    public IActionResult DeleteImage(int id)
    {
        var values = _context.Galleries.FirstOrDefault(x => x.GalleryID == id);
        _context.Galleries.Remove(values);
        _context.SaveChanges();
        return RedirectToAction("Index", "Gallery");
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
    [HttpGet]
    public IActionResult CreateImage()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> CreateImage(CreateImageViewModel model)
    {
        var resource = Directory.GetCurrentDirectory();
        var extension = Path.GetExtension(model.Image.FileName);
        var imageName = Guid.NewGuid() + extension;
        var savelocation = resource + "/wwwroot/galleryImages/" + imageName;
        var stream = new FileStream(savelocation, FileMode.Create);
        await model.Image.CopyToAsync(stream);

        Gallery galery = new Gallery
        {
            Status = true,
            ImageName = model.ImageName,
            ImageUrl = imageName
        };

        _context.Galleries.Add(galery);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }
}
