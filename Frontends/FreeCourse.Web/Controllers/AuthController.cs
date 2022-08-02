using Microsoft.AspNetCore.Mvc;

namespace FreeCourse.Web.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult SignIn()
        {
            return View();
        }
    }
}
