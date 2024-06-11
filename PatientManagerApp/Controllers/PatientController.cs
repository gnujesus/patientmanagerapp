using Microsoft.AspNetCore.Mvc;

namespace PatientManagerApp.Controllers
{
    public class PatientController: Controller
    {
        private readonly ILogger<HomeController> _logger;

        public PatientController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }


        public IActionResult Index()
        {
            return View();
        }

    }
}
