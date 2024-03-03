using KidKinder.Entities;
using KidKinder.Models;
using Microsoft.AspNetCore.Mvc;

namespace KidKinder.Controllers;
public class FeatureController : Controller
{
    private readonly Context _context;

    public FeatureController(Context context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var values = _context.Features.ToList();
        return View(values);
    }
    [HttpGet]
    public IActionResult UpdateFeature(int id)
    {
        var values = _context.Features.FirstOrDefault(x => x.FeatureID == id);
        if (values != null)
        {
            UpdateFeatureViewModel model = new UpdateFeatureViewModel
            {
                FeatureID = values.FeatureID,
                Description = values.Description,
                Title = values.Title,
                Header = values.Header,
                ImageUrl = values.ImageUrl
            };
            return View(model);
        }
        return View();
    }
    [HttpPost]
    public IActionResult UpdateFeature(UpdateFeatureViewModel model)
    {
        var values = _context.Features.FirstOrDefault(x => x.FeatureID == model.FeatureID);
        if (values != null)
        {
            values.Title = model.Title;
            values.Header = model.Header;
            values.ImageUrl = model.ImageUrl;
            values.Description = model.Description;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        return View();
    }
}
