using KidKinder.Entities;
using KidKinder.Models;
using Microsoft.AspNetCore.Mvc;

namespace KidKinder.Areas.Admin.Controllers;


[Area("Admin")]
[Route("Admin/[controller]/[action]/{id?}")]
public class ClassController : Controller
{
    private readonly Context _context;

    public ClassController(Context context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var values = _context.KidClasses.ToList();
        return View(values);
    }
    public IActionResult DeleteClass(int id)
    {
        var values = _context.KidClasses.FirstOrDefault(x => x.KidClassID == id);
        _context.KidClasses.Remove(values);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }
    [HttpGet]
    public IActionResult CreateClass()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> CreateClass(CreateClassViewModel model)
    {
        var resource = Directory.GetCurrentDirectory();
        var extension = Path.GetExtension(model.Image.FileName);
        var imageName = Guid.NewGuid() + extension;
        var savelocation = resource + "/wwwroot/classImages/" + imageName;
        var stream = new FileStream(savelocation, FileMode.Create);
        await model.Image.CopyToAsync(stream);

        KidClass classes = new KidClass
        {
            Name = model.Name,
            AgeOfKids = model.AgeOfKids,
            TotalSeats = model.TotalSeats,
            ClassTime = model.ClassTime,
            Description = model.Description,
            ImageUrl = imageName,
            TutionFee = model.TutionFee
        };

        _context.KidClasses.Add(classes);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult UpdateClass(int id)
    {
        var values = _context.KidClasses.FirstOrDefault(x => x.KidClassID == id);

        if (values != null)
        {
            UpdateClassViewModel model = new UpdateClassViewModel
            {
                KidClassID = values.KidClassID,
                AgeOfKids = values.AgeOfKids,
                ClassTime = values.ClassTime,
                Description = values.Description,
                ImageUrl = values.ImageUrl,
                Name = values.Name,
                TotalSeats = values.TotalSeats,
                TutionFee = values.TutionFee
            };

            return View(model);
        }
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> UpdateClass(UpdateClassViewModel model)
    {
        var values = _context.KidClasses.FirstOrDefault(x => x.KidClassID == model.KidClassID);

        if (model.Image != null)
        {
            var resource = Directory.GetCurrentDirectory();
            var extension = Path.GetExtension(model.Image.FileName);
            var imageName = Guid.NewGuid() + extension;
            var savelocation = resource + "/wwwroot/classImages/" + imageName;
            var stream = new FileStream(savelocation, FileMode.Create);
            await model.Image.CopyToAsync(stream);
            model.ImageUrl = imageName;
        }


        values.Name = model.Name;
        values.TotalSeats = model.TotalSeats;
        values.AgeOfKids = model.AgeOfKids;
        values.ClassTime = model.ClassTime;
        values.Description = model.Description;
        values.ImageUrl = model.ImageUrl;
        values.TutionFee = model.TutionFee;
        _context.Update(values);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }
}
