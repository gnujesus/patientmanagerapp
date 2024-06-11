using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PatientManagerApp.Core.Application.Interfaces.Services;
using PatientManagerApp.Core.Application.ViewModels.User;
using PatientManagerApp.Core.Application.Helpers;

namespace WebApp.PatientManagerApp.Controllers
{
    public class UserController : Controller
    {

        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginUserViewModel loginUserViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(loginUserViewModel);
            }

            UserViewModel userViewModel = await _userService.Login(loginUserViewModel);

            if(userViewModel != null)
            {
                HttpContext.Session.Set<UserViewModel>("user", userViewModel);
                return RedirectToRoute(new { controller="Home", action="Index"});
            } else
            {
                ModelState.AddModelError("userValidation", "Error. Wrong username or password");
            }

            return View(loginUserViewModel);
        }

        public async Task<IActionResult> Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(SaveUserViewModel saveUserViewModel)
        {
            List<UserViewModel> userViewModel = await _userService.GetAllViewModelAsync();

            if (!ModelState.IsValid)
            {
                return View(saveUserViewModel);
            }

            await _userService.Insert(saveUserViewModel);
            return RedirectToRoute(new { controller="Home", action="Index"});
        }
    }
}
