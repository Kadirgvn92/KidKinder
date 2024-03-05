using KidKinder.Entities;
using Microsoft.AspNetCore.Mvc;

namespace KidKinder.ViewComponents.AdminViewComponents;

public class _AdminTestimonialPartial : ViewComponent
{
    private readonly Context _context;

    public _AdminTestimonialPartial(Context context)
    {
        _context = context;
    }

    public IViewComponentResult Invoke()
    {
        var values = _context.Testimonials.ToList();
        return View(values);
    }
}
