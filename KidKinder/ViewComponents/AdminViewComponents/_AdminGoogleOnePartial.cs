using KidKinder.Entities;
using Microsoft.AspNetCore.Mvc;

namespace KidKinder.ViewComponents.AdminViewComponents;

public class _AdminGoogleOnePartial : ViewComponent
{
    private readonly Context _context;

    public _AdminGoogleOnePartial(Context context)
    {
        _context = context;
    }

    public IViewComponentResult Invoke()
    {

        return View();  
    }
}
