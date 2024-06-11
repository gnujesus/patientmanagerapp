using Microsoft.AspNetCore.Mvc;

namespace WebApp.PatientManagerApp.Controllers
{
    public class LaboratoryResultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
