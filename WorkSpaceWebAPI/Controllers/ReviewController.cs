using Microsoft.AspNetCore.Mvc;

namespace WorkSpaceWebAPI.Controllers
{
    public class ReviewController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
