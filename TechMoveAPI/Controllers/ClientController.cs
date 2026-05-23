using Microsoft.AspNetCore.Mvc;

namespace TechMoveAPI.Controllers
{
    public class ClientController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
