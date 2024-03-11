using KidKinder.Entities;
using Microsoft.AspNetCore.Mvc;

namespace KidKinder.ViewComponents;

public class _GetInTouchPartial : ViewComponent
{
    private readonly Context _context;

    public _GetInTouchPartial(Context context)
    {
        _context = context;
    }

    public IViewComponentResult Invoke()
    {
        var values = _context.GetInTouches.ToList();
        return View(values);
    }
}
