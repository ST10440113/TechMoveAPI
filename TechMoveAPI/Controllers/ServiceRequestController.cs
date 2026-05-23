using Microsoft.AspNetCore.Mvc;

namespace TechMoveAPI.Controllers
{
    public class ServiceRequestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
