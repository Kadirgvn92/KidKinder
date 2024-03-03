using Microsoft.AspNetCore.Mvc;

namespace KidKinder.ViewComponents.UIViewComponents;

public class _FacilitiyPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
