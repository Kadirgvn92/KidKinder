using KidKinder.Entities;
using Microsoft.AspNetCore.Mvc;

namespace KidKinder.ViewComponents.UIViewComponents;

public class _TeacherPartial : ViewComponent
{
    private readonly Context _context;

    public _TeacherPartial(Context context)
    {
        _context = context;
    }

    public IViewComponentResult Invoke()
    {
        var values = _context.Teachers.ToList();
        return View(values);
    }
}
