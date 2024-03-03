using Microsoft.AspNetCore.Mvc;

namespace KidKinder.ViewComponents.UIViewComponents;

public class _NewsletterPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
