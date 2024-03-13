using KidKinder.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace KidKinder.ViewComponents.UIViewComponents;

public class _RegisterPartial : ViewComponent
{
    private readonly Context _context;

    public _RegisterPartial(Context context)
    {
        _context = context;
    }

    public IViewComponentResult Invoke()
    {
        List<SelectListItem> classes = (from x in _context.KidClasses.ToList()
                                        select new SelectListItem
                                        {
                                            Text = x.Name,
                                            Value = x.KidClassID.ToString()
                                        }).ToList();
        ViewBag.v = classes;
        return View();  
    }
}
