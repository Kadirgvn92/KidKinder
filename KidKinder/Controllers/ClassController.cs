using KidKinder.Entities;
using KidKinder.Models;
using Microsoft.AspNetCore.Mvc;

namespace KidKinder.Controllers;
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
    public IActionResult CreateClass(CreateClassViewModel model)
    {
        KidClass classes = new KidClass
        {
            Name = model.Name,
            AgeOfKids = model.AgeOfKids,
            TotalSeats = model.TotalSeats,
            ClassTime = model.ClassTime,
            Description = model.Description,
            ImageUrl = model.ImageUrl,
            TutionFee = model.TutionFee
        };

        _context.KidClasses.Add(classes);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }
}
