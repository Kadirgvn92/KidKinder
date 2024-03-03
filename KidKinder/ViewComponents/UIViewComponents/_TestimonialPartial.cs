using Microsoft.AspNetCore.Mvc;

namespace KidKinder.ViewComponents.UIViewComponents;

public class _TestimonialPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
