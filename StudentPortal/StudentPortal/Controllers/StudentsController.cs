using Microsoft.AspNetCore.Mvc;

namespace StudentPortal.Controllers
{
    public class StudentsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
