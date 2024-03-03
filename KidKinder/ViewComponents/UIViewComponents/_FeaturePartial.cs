using KidKinder.Entities;
using Microsoft.AspNetCore.Mvc;

namespace KidKinder.ViewComponents.UIViewComponents;

public class _FeaturePartial : ViewComponent
{
    private readonly Context _context;

    public _FeaturePartial(Context context)
    {
        _context = context;
    }

    public IViewComponentResult Invoke()
    {
        var values = _context.Features.ToList();
        return View(values);
    }
}
