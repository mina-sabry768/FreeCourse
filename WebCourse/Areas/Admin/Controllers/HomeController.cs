using Domin.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebCourse.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Permissions.Home.View)]
    public class HomeController : Controller
	{
        [Authorize(Permissions.Home.View)]
        public IActionResult Index()
		{
			return View();
		}
        [AllowAnonymous]
        public IActionResult Denied()
        {
            return View();
        }
    }
}
