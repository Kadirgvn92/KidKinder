using KidKinder.Entities;
using KidKinder.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace KidKinder.Controllers;
[AllowAnonymous]
public class LoginController : Controller
{
    private readonly Context _context;
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;

    public LoginController(Context context, SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
    {
        _context = context;
        _signInManager = signInManager;
        _userManager = userManager;
    }
    [HttpGet]
    public IActionResult SignUp()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> SignUp(RegisterViewModel p)
    {
        AppUser appUser = new AppUser()
        {
            Name = p.Name,
            Surname = p.Surname,
            Email = p.Mail,
            UserName = p.Username,
            PhoneNumber = p.PhoneNumber,
        };
        var result = await _userManager.CreateAsync(appUser, p.Password);
        if (result.Succeeded)
        {
            ViewBag.success = "Kayıt başarılı şekilde gerçekleşmiştir.";
            return RedirectToAction("SignIn");
        }
        else
        {
            foreach (var item in result.Errors)
            {
                ModelState.AddModelError("", item.Description);
            }
        }
        return View(p);
    }

    [HttpGet]
    public IActionResult SignIn()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> SignIn(UserSignInViewModel model)
    {
        var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, false, true);
        if (result.Succeeded)
        {
            return RedirectToAction("Index", "Dashboard", new { area = "Admin" });
        }
        return View();
    }
    [HttpGet]
    public async Task<IActionResult> LogOut()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Index", "Default");
    }
}
