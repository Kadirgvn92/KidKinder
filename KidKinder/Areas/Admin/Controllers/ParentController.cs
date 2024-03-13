using KidKinder.Areas.Admin.Models;
using KidKinder.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace KidKinder.Areas.Admin.Controllers;

[Area("Admin")]
[Route("Admin/[controller]/[action]/{id?}")]
public class ParentController : Controller
{
    private readonly Context _context;

    public ParentController(Context context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var values = _context.Parents.ToList();
        return View(values);
    }
    public IActionResult DeleteParent(int id)
    {
        var values = _context.Parents.FirstOrDefault(x => x.ParentID == id);
        _context.Parents.Remove(values);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }
    [HttpGet]
    public IActionResult CreateParent()
    {

        return View();
    }
    [HttpPost]
    public async Task<IActionResult> CreateParent(CreateParentViewModel model)
    {
       
        Parent Parent = new Parent
        {
            Name = model.Name,
            Address = model.Address,
            DebtDescription = model.DebtDescription,
            Mail = model.Mail,
            Phone = model.Phone,
            SecondPhone = model.SecondPhone,
            TotalDebt = model.TotalDebt
        };

        _context.Parents.Add(Parent);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult UpdateParent(int id)
    {
        var values = _context.Parents.FirstOrDefault(x => x.ParentID == id);

        if (values != null)
        {
            UpdateParentViewModel model = new UpdateParentViewModel
            {
                ParentID = values.ParentID,
                Name = values.Name,
                Address = values.Address,
                DebtDescription = values.DebtDescription,
                Mail = values.Mail,
                Phone = values.Phone,
                SecondPhone = values.SecondPhone,
                TotalDebt = values.TotalDebt
            };

            return View(model);
        }
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> UpdateParent(UpdateParentViewModel model)
    {
        var values = _context.Parents.FirstOrDefault(x => x.ParentID == model.ParentID);

        values.Name = model.Name;
        values.Address = model.Address;
        values.DebtDescription = model.DebtDescription;
        values.Mail = model.Mail;
        values.Phone = model.Phone;
        values.SecondPhone = model.SecondPhone;
        values.TotalDebt = model.TotalDebt;

        _context.Update(values);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }
}
