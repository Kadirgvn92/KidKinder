using KidKinder.Areas.Admin.Models;
using KidKinder.Entities;
using KidKinder.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace KidKinder.Controllers;

[Area("Admin")]
[Route("Admin/[controller]/[action]/{id?}")]
public class TeacherController : Controller
{
    private readonly Context _context;

    public TeacherController(Context context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var values = _context.Teachers.Include(x => x.Class).ToList();
        return View(values);
    }
    public IActionResult DeleteTeacher(int id)
    {
        var values = _context.Teachers.FirstOrDefault(x => x.TeacherID == id);
        _context.Teachers.Remove(values);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }
    [HttpGet]
    public IActionResult CreateTeacher()
    {

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
    public async Task<IActionResult> CreateTeacher(CreateTeacherViewModel model)
    {
        var resource = Directory.GetCurrentDirectory();
        var extension = Path.GetExtension(model.Image.FileName);
        var imageName = Guid.NewGuid() + extension;
        var savelocation = resource + "/wwwroot/teacherImages/" + imageName;
        var stream = new FileStream(savelocation, FileMode.Create);
        await model.Image.CopyToAsync(stream);

        Teacher teacher = new Teacher
        {
           Name = model.Name,
           Branch = model.Branch,
           FacebookUrl = model.FacebookUrl,
           InstagramUrl = model.InstagramUrl,
           LinkedinUrl = model.LinkedinUrl,
           KidClassID = model.KidClassID,
           ImageUrl = imageName,
        };

        _context.Teachers.Add(teacher);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult UpdateTeacher(int id)
    {
        var values = _context.Teachers.FirstOrDefault(x => x.TeacherID == id);

        List<SelectListItem> classes = (from x in _context.KidClasses.ToList()
                                        select new SelectListItem
                                        {
                                            Text = x.Name,
                                            Value = x.KidClassID.ToString()
                                        }).ToList();
        ViewBag.v = classes;

        if (values != null)
        {
            UpdateTeacherViewModel model = new UpdateTeacherViewModel
            {
                TeacherID = values.TeacherID,
                Branch = values.Branch,
                ImageUrl= values.ImageUrl,
                LinkedinUrl = values.LinkedinUrl,   
                InstagramUrl= values.InstagramUrl,
                FacebookUrl= values.FacebookUrl,
                Name = values.Name  
            };

            return View(model);
        }
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> UpdateTeacher(UpdateTeacherViewModel model)
    {
        var values = _context.Teachers.FirstOrDefault(x => x.TeacherID == model.TeacherID);

        if (model.Image != null)
        {
            var resource = Directory.GetCurrentDirectory();
            var extension = Path.GetExtension(model.Image.FileName);
            var imageName = Guid.NewGuid() + extension;
            var savelocation = resource + "/wwwroot/teacherImages/" + imageName;
            var stream = new FileStream(savelocation, FileMode.Create);
            await model.Image.CopyToAsync(stream);
            model.ImageUrl = imageName;
        }


        values.Name = model.Name;
        values.Branch = model.Branch;
        values.ImageUrl = model.ImageUrl;
        values.LinkedinUrl = model.LinkedinUrl;
        values.InstagramUrl = model.InstagramUrl;
        values.FacebookUrl = model.FacebookUrl;

        _context.Update(values);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }
}
