using Microsoft.AspNetCore.Mvc;

namespace WebApp.PatientManagerApp.Controllers
{
    public class LaboratoryTestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
