using KidKinder.Entities;
using Microsoft.AspNetCore.Mvc;

namespace KidKinder.Controllers;
public class LoginController : Controller
{
    private readonly Context _context;

    public LoginController(Context context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult AdminLogin()
    {
        return View();
    }
    [HttpPost]
    public IActionResult AdminLogin(Admin admin)
    {
        var result = _context.Admins.FirstOrDefault(x=> x.Username == admin.Username && x.Password == admin.Password);
        if (result != null)
        {
            
        }
        return View();
    }
}
