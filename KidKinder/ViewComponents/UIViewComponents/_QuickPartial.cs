using Microsoft.AspNetCore.Mvc;

namespace KidKinder.ViewComponents.UIViewComponents;

public class _QuickPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
