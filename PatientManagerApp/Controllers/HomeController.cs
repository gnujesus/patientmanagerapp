using Microsoft.AspNetCore.Mvc;

namespace PatientManagerApp.Controllers
{
    public class DoctorController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public DoctorController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }


        public IActionResult Index()
        {
            return View();
        }

    }
}
