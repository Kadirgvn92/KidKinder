using Microsoft.AspNetCore.Mvc;

namespace KidKinder.ViewComponents.UIViewComponents;

public class _SocialPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();  
    }
}
