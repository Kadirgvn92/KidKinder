using KidKinder.Entities;
using Microsoft.AspNetCore.Mvc;

namespace KidKinder.ViewComponents.UIViewComponents;

public class _ClassesPartial : ViewComponent
{
    private readonly Context _context;

    public _ClassesPartial(Context context)
    {
        _context = context;
    }

    public IViewComponentResult Invoke()
    {
        var values = _context.KidClasses.ToList();
        return View(values);
    }
}
