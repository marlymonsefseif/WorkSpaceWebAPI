using Microsoft.AspNetCore.Mvc;

namespace WorkSpaceWebAPI.Controllers
{
    public class ContactMessageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
