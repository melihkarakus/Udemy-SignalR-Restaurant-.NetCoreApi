using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.Controllers
{
    public class AdminLayout : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
