using KidKinder.Entities;
using KidKinder.Models;
using Microsoft.AspNetCore.Mvc;

namespace KidKinder.ViewComponents.AdminViewComponents;

public class _AdminProgressPartial : ViewComponent
{
    private readonly Context _context;

    public _AdminProgressPartial(Context context)
    {
        _context = context;
    }

    public IViewComponentResult Invoke()
    {
        var capacity = _context.KidClasses.Select(x => new ProgressBarViewModel{
            ClassName = x.Name,
            Capacity = ((double)x.Kids.Count / x.TotalSeats) * 100 
        }).ToList();
        return View(capacity);  
    }
}
