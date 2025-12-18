using Microsoft.AspNetCore.Mvc;

namespace Lagersystem.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
