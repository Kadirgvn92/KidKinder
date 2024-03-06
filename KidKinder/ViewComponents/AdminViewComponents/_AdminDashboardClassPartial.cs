using KidKinder.Entities;
using Microsoft.AspNetCore.Mvc;

namespace KidKinder.ViewComponents.AdminViewComponents;

public class _AdminDashboardClassPartial : ViewComponent
{
    private readonly Context _context;

    public _AdminDashboardClassPartial(Context context)
    {
        _context = context;
    }

    public IViewComponentResult Invoke()
    {
        var values = _context.KidClasses.ToList();
        return View(values);  
    }
}
