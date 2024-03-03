using Microsoft.AspNetCore.Mvc;

namespace KidKinder.ViewComponents.UIViewComponents;

public class _ClassesPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
