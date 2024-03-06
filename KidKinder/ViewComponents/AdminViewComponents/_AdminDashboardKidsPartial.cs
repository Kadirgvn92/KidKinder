using KidKinder.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KidKinder.ViewComponents.AdminViewComponents;

public class _AdminDashboardKidsPartial : ViewComponent
{
    private readonly Context _context;

    public _AdminDashboardKidsPartial(Context context)
    {
        _context = context;
    }

    public IViewComponentResult Invoke()
    {
        var values = _context.Kids.Include(x => x.Parents).ToList();
        return View(values);
    }
}
