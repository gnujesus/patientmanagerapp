using Microsoft.AspNetCore.Mvc;
using PatientManagerApp.Core.Application.Interfaces.Services;
using PatientManagerApp.Core.Application.ViewModels.Doctor;
using PatientManagerApp.Core.Application.ViewModels.User;
using WebApp.PatientManagerApp.Middlewares;
using PatientManagerApp.Core.Application.Helpers;
using System.Runtime.CompilerServices;

namespace PatientManagerApp.Controllers
{
    public class DoctorController : Controller
    {
        private readonly IDoctorService _doctorService;
        private readonly ValidateUserSession _validateUserSession;
        private readonly UserViewModel _userViewModel;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DoctorController(IDoctorService doctorService, ValidateUserSession validateUserSession, IHttpContextAccessor httpContextAccessor)
        {
            _doctorService = doctorService;
            _validateUserSession = validateUserSession;
            _httpContextAccessor = httpContextAccessor;
            _userViewModel = _httpContextAccessor.HttpContext.Session.Get<UserViewModel>("user");
        }


        public async Task<IActionResult> Index()
        {
            List<DoctorViewModel> doctorVm = await _doctorService.GetAllViewModelAsync();

            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "User", action = "Login" });
            }
            return View(doctorVm);
        }

        public IActionResult Save()
        {
            SaveDoctorViewModel vm = new();

            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "User", action = "Login" });
            }

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Save(SaveDoctorViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            vm.ClinicId = _userViewModel.ClinicId;

            SaveDoctorViewModel doctorVm = await _doctorService.Insert(vm);
            if(doctorVm != null && doctorVm.Id != 0)
            {
                doctorVm.PicturePath = UploadFile(vm.File, doctorVm.Id);
                await _doctorService.Update(doctorVm);
            }
            return RedirectToRoute(new { controller = "Home", action = "Index" });
        }

        public async Task<IActionResult> Update(int id)
        {
            return View("Save", await _doctorService.GetByIdCreateViewModel(id));
        }

        [HttpPost]
        public async Task<IActionResult> Update(SaveDoctorViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            vm.PicturePath = UploadFile(vm.File, vm.Id);
            await _doctorService.Update(vm);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _doctorService.Delete(id);
            return RedirectToAction("Index");
        }

        private string UploadFile(IFormFile file, int id)
        {
            string basePath = $"/static/Images/Doctors/{id}";
            string path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot{basePath}");

            // Create if not exists
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            Guid guid = Guid.NewGuid();
            FileInfo fileInfo = new(file.FileName);
            string fileName = fileInfo.Name + fileInfo.Extension;

            string fileNameWithPath = Path.Combine(path, fileName);

            using(FileStream stream = new(fileNameWithPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            return Path.Combine(basePath, fileName);
        }

    }
}
