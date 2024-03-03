using Microsoft.AspNetCore.Mvc;

namespace KidKinder.ViewComponents.UIViewComponents;

public class _RegisterPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();  
    }
}
