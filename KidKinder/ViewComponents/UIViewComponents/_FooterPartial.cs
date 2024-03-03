using Microsoft.AspNetCore.Mvc;

namespace KidKinder.ViewComponents.UIViewComponents;

public class _FooterPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();  
    }
}
