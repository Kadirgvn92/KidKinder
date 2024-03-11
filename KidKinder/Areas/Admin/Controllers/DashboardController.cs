using KidKinder.Entities;
using KidKinder.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KidKinder.Areas.Admin.Controllers;

[Area("Admin")]
[Route("Admin/[controller]/[action]/{id?}")]
public class DashboardController : Controller
{
    private readonly Context _context;

    public DashboardController(Context context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var classes = _context.KidClasses.Count();
        ViewBag.Class = classes;
        var teacher = _context.Teachers.Count();
        ViewBag.Teachers = teacher;
        var kids = _context.Kids.Count();
        ViewBag.Kids = kids;
        var capacity = _context.KidClasses.Sum(x => x.TotalSeats) - kids;
        ViewBag.Capacity = capacity;


        return View();
    }
    public IActionResult GetStudentClassData()
    {
        var values = _context.KidClasses.Select(x => new GoogleChartViewModel 
        {
            ClassName = x.Name,
            Capacity = x.TotalSeats,

        }).ToList();

        return Json(new { jsonList = values });
    }
}
