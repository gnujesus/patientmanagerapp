using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PatientManagerApp.Core.Application.Interfaces.Services;
using PatientManagerApp.Core.Application.ViewModels.User;
using PatientManagerApp.Core.Application.Helpers;
using WebApp.PatientManagerApp.Middlewares;

namespace WebApp.PatientManagerApp.Controllers
{
    public class UserController : Controller
    {

        private readonly IUserService _userService;
        private readonly ValidateUserSession _validateUserSession;

        public UserController(IUserService userService, ValidateUserSession validateUserSession)
        {
            _userService = userService;
            _validateUserSession = validateUserSession;
        }

        public async Task<IActionResult> Index()
        {
            List<UserViewModel> userViewModelList = await _userService.GetAllViewModelAsync();

            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "User", action = "Login" });
            }
            return View(userViewModelList);
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
            SaveUserViewModel userVm = new();
            return View(userVm);
        }

        [HttpPost]
        public async Task<IActionResult> Register(SaveUserViewModel saveUserViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(saveUserViewModel);
            }

            await _userService.Insert(saveUserViewModel);
            return RedirectToRoute(new { controller="Home", action="Index"});
        }

        public async Task<IActionResult> Update(int id)
        {
            return View("Register", await _userService.GetByIdCreateViewModel(id));
        }

        [HttpPost]
        public async Task<IActionResult> Update(SaveUserViewModel saveUserViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(saveUserViewModel);
            }

            await _userService.Update(saveUserViewModel);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _userService.Delete(id);
            return RedirectToAction("Index");
        }

    }
}
