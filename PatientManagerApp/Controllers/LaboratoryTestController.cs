using Microsoft.AspNetCore.Mvc;
using PatientManagerApp.Core.Application.Interfaces.Services;
using PatientManagerApp.Core.Application.ViewModels.LaboratoryTest;
using PatientManagerApp.Core.Application.ViewModels.User;
using WebApp.PatientManagerApp.Middlewares;
using PatientManagerApp.Core.Application.Helpers;
using PatientManagerApp.Core.Application.Services;

namespace WebApp.PatientManagerApp.Controllers
{
    public class LaboratoryTestController : Controller
    {

        private readonly ILaboratoryTestService _laboratoryTestService;
        private readonly ValidateUserSession _validateUserSession;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserViewModel _userViewModel;

        public LaboratoryTestController(ILaboratoryTestService laboratoryTestService, ValidateUserSession validateUserSession, IHttpContextAccessor httpContextAccessor)
        {
            _laboratoryTestService = laboratoryTestService;
            _validateUserSession = validateUserSession;
            _httpContextAccessor = httpContextAccessor;
            _userViewModel = _httpContextAccessor.HttpContext.Session.Get<UserViewModel>("user");
        }

        public async Task<IActionResult> Index()
        {

            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "User", action = "Login" });
            }

            List<LaboratoryTestViewModel> laboratoryTestViewModelList = await _laboratoryTestService.GetAllViewModelAsync();

            return View(laboratoryTestViewModelList);
        }

        public IActionResult Save()
        {
            SaveLaboratoryTestViewModel saveLaboratoryTestViewModel = new();

            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "User", action = "Login" });
            }

            return View(saveLaboratoryTestViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Save(SaveLaboratoryTestViewModel saveLaboratoryTestViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(saveLaboratoryTestViewModel);
            }

            saveLaboratoryTestViewModel.ClinicId = _userViewModel.ClinicId;

            await _laboratoryTestService.Insert(saveLaboratoryTestViewModel);
            return RedirectToRoute(new { controller = "Home", action = "Index" });
        }

        public async Task<IActionResult> Update(int id)
        {
            return View("Save", await _laboratoryTestService.GetByIdCreateViewModel(id));
        }

        [HttpPost]
        public async Task<IActionResult> Update(SaveLaboratoryTestViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            await _laboratoryTestService.Update(vm);
            return RedirectToAction("Index");
        }


        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _laboratoryTestService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
