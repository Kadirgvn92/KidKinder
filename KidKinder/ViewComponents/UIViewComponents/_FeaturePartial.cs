using Microsoft.AspNetCore.Mvc;

namespace KidKinder.ViewComponents.UIViewComponents;

public class _FeaturePartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
