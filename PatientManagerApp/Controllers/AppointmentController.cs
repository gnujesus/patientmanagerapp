using Microsoft.AspNetCore.Mvc;
using PatientManagerApp.Core.Application.Interfaces.Services;
using WebApp.PatientManagerApp.Middlewares;

namespace WebApp.PatientManagerApp.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly IUserService _userService;
        private readonly ValidateUserSession _validateUserSession;

        public AppointmentController(IUserService userService, ValidateUserSession validateUserSession)
        {
            _userService = userService;
            _validateUserSession = validateUserSession;
        }

        public IActionResult Index()
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "User", action = "Login" });
            }

            return View();
        }
    }
}
