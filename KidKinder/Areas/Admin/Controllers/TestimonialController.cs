using KidKinder.Areas.Admin.Models;
using KidKinder.Entities;
using KidKinder.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Drawing;

namespace KidKinder.Areas.Admin.Controllers;

[Area("Admin")]
[Route("Admin/[controller]/[action]/{id?}")]
public class TestimonialController : Controller
{
    private readonly Context _context;

    public TestimonialController(Context context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var values = _context.Testimonials.ToList();
        return View(values);
    }
    public IActionResult DeleteTestimonial(int id)
    {
        var values = _context.Testimonials.FirstOrDefault(x => x.TestimonialID == id);
        _context.Testimonials.Remove(values);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }
    [HttpGet]
    public IActionResult CreateTestimonial()
    {

        return View();
    }
    [HttpPost]
    public async Task<IActionResult> CreateTestimonial(CreateTestimonialViewModel model)
    {
        var resource = Directory.GetCurrentDirectory();
        var extension = Path.GetExtension(model.Image.FileName);
        var imageName = Guid.NewGuid() + extension;
        var savelocation = resource + "/wwwroot/testimonialImages/" + imageName;
        var stream = new FileStream(savelocation, FileMode.Create);
        await model.Image.CopyToAsync(stream);

        Testimonial Testimonial = new Testimonial
        {
            Name = model.Name,
            Comment = model.Comment,
            WhosParent = model.WhosParent,
            ImageUrl = imageName,
        };

        _context.Testimonials.Add(Testimonial);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult UpdateTestimonial(int id)
    {
        var values = _context.Testimonials.FirstOrDefault(x => x.TestimonialID == id);

        if (values != null)
        {
            UpdateTestimonialViewModel model = new UpdateTestimonialViewModel
            {
                TestimonialID = values.TestimonialID,
                Comment = values.Comment,
                WhosParent = values.WhosParent,
                ImageUrl = values.ImageUrl,
                Name = values.Name
            };

            return View(model);
        }
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> UpdateTestimonial(UpdateTestimonialViewModel model)
    {
        var values = _context.Testimonials.FirstOrDefault(x => x.TestimonialID == model.TestimonialID);

        if (model.Image != null)
        {
            var resource = Directory.GetCurrentDirectory();
            var extension = Path.GetExtension(model.Image.FileName);
            var imageName = Guid.NewGuid() + extension;
            var savelocation = resource + "/wwwroot/testimonialImages/" + imageName;
            var stream = new FileStream(savelocation, FileMode.Create);
            await model.Image.CopyToAsync(stream);
            model.ImageUrl = imageName;
        }

        values.Name = model.Name;
        values.Comment = model.Comment;
        values.WhosParent = model.WhosParent;
        values.ImageUrl = model.ImageUrl;

        _context.Update(values);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }
}
