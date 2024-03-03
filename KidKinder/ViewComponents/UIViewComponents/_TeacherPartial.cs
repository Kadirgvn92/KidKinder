using Microsoft.AspNetCore.Mvc;

namespace KidKinder.ViewComponents.UIViewComponents;

public class _TeacherPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
