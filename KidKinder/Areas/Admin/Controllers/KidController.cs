using KidKinder.Areas.Admin.Models;
using KidKinder.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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
        var values = _context.Kids.ToList();
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
        ViewBag.v = parents;
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
    public async Task<IActionResult> CreateKid(CreateKidViewModel model)
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

        if (values != null)
        {
            UpdateKidViewModel model = new UpdateKidViewModel
            {
                KidID = values.KidID,
                Name = values.Name
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

        _context.Update(values);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }
}
