using Microsoft.AspNetCore.Mvc;

namespace KidKinder.ViewComponents.UIViewComponents;

public class _AboutPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
