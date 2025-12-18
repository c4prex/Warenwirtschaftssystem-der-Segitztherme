using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Lagersystem.Models.ViewModels;
using Lagersystem.Data;

public class DashboardController : Controller
{
    private readonly WarenwirtschaftContext _context;

    public DashboardController(WarenwirtschaftContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var artikel = _context.Artikels
            .Include(a => a.Lager)
            .ToList();

        var model = new DashboardViewModel
        {
   
        };

        return View(model);
    }
}
