using KidKinder.Entities;
using Microsoft.AspNetCore.Mvc;

namespace KidKinder.ViewComponents.UIViewComponents;

public class _TestimonialPartial : ViewComponent
{
    private readonly Context _context;

    public _TestimonialPartial(Context context)
    {
        _context = context;
    }

    public IViewComponentResult Invoke()
    {
        var values = _context.Testimonials.ToList();
        return View(values);
    }
}
