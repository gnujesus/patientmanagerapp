using Microsoft.AspNetCore.Mvc;

namespace WebApp.PatientManagerApp.Controllers
{
    public class AppointmentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
