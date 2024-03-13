using KidKinder.Areas.Admin.Models;
using KidKinder.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace KidKinder.Areas.Admin.Controllers;

[Area("Admin")]
[Route("Admin/[controller]/[action]/{id?}")]
public class KidController : Controller
{
    private readonly Context _context;

    public KidController(Context context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var values = _context.Kids.Include(x => x.Parents).Include(y => y.Class).ToList();
        return View(values);
    }
    public IActionResult DeleteKid(int id)
    {
        var values = _context.Kids.FirstOrDefault(x => x.KidID == id);
        _context.Kids.Remove(values);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }
    [HttpGet]
    public IActionResult CreateKid()
    {
        List<SelectListItem> parents = (from x in _context.Parents.ToList()
                                        select new SelectListItem
                                        {
                                            Text = x.Name,
                                            Value = x.ParentID.ToString()
                                        }).ToList();
        ViewBag.v1 = parents;
        List<SelectListItem> classes = (from x in _context.KidClasses.ToList()
                                        select new SelectListItem
                                        {
                                            Text = x.Name,
                                            Value = x.KidClassID.ToString()
                                        }).ToList();
        ViewBag.v2 = classes;
        return View();
    }
    [HttpPost]
    public IActionResult CreateKid(CreateKidViewModel model)
    {

        Kid Kid = new Kid
        {
            Age = model.Age,
            Name = model.Name,
            RegisterDate = Convert.ToDateTime(DateTime.Now.ToShortDateString()),
            KidClassID = model.KidClassID,
            ParentID = model.ParentID,
        };

        _context.Kids.Add(Kid);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult UpdateKid(int id)
    {
        var values = _context.Kids.FirstOrDefault(x => x.KidID == id);

        List<SelectListItem> parents = (from x in _context.Parents.ToList()
                                        select new SelectListItem
                                        {
                                            Text = x.Name,
                                            Value = x.ParentID.ToString()
                                        }).ToList();
        ViewBag.v1 = parents;
        List<SelectListItem> classes = (from x in _context.KidClasses.ToList()
                                        select new SelectListItem
                                        {
                                            Text = x.Name,
                                            Value = x.KidClassID.ToString()
                                        }).ToList();
        ViewBag.v2 = classes;

        if (values != null)
        {
            UpdateKidViewModel model = new UpdateKidViewModel
            {
                KidID = values.KidID,
                Name = values.Name,
                Age= values.Age,    
                ParentID = values.ParentID,
                KidClassID = values.KidClassID,
            };

            return View(model);
        }
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> UpdateKid(UpdateKidViewModel model)
    {
        var values = _context.Kids.FirstOrDefault(x => x.KidID == model.KidID);


        values.Name = model.Name;
        values.ParentID = model.ParentID;
        values.KidClassID = model.KidClassID;
        values.Age = model.Age;

        _context.Update(values);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }
}
