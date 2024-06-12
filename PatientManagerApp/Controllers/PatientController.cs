using Microsoft.AspNetCore.Mvc;
using PatientManagerApp.Core.Application.Interfaces.Services;
using PatientManagerApp.Core.Application.ViewModels.Patient;
using PatientManagerApp.Core.Application.ViewModels.User;
using WebApp.PatientManagerApp.Middlewares;
using PatientManagerApp.Core.Application.Helpers;

namespace PatientManagerApp.Controllers
{
    public class PatientController: Controller
    {

        private readonly IPatientService _patientService;
        private readonly ValidateUserSession _validateUserSession;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserViewModel _userViewModel;

        public PatientController(IPatientService patientService, ValidateUserSession validateUserSession,IHttpContextAccessor httpContextAccessor )
        {
            _patientService = patientService;
            _validateUserSession = validateUserSession;
            _httpContextAccessor = httpContextAccessor;
            _userViewModel = _httpContextAccessor.HttpContext.Session.Get<UserViewModel>("user");
        }

        public async Task<IActionResult> Index()
        {
            List<PatientViewModel> patientVmList = await _patientService.GetAllViewModelAsync();

            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "User", action = "Login" });
            }

            return View(patientVmList);
        }

        public IActionResult Save()
        {
            SavePatientViewModel vm = new();

            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "User", action = "Login" });
            }

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Save(SavePatientViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            vm.ClinicId = _userViewModel.ClinicId;

            SavePatientViewModel patientVm = await _patientService.Insert(vm);

            if(patientVm != null && patientVm.Id != 0)
            {
                patientVm.PicturePath = UploadFile(vm.File, patientVm.Id);
                await _patientService.Update(patientVm);
            }

            return RedirectToRoute(new { controller = "Home", action = "Index" });
        }

        public async Task<IActionResult> Update(int id)
        {
            return View("Save", await _patientService.GetByIdCreateViewModel(id));
        }

        [HttpPost]
        public async Task<IActionResult> Update(SavePatientViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View("Save", vm);
            }

            vm.PicturePath = UploadFile(vm.File, vm.Id);
            await _patientService.Update(vm);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _patientService.Delete(id);
            return RedirectToAction("Index");
        }

        private string UploadFile(IFormFile file, int id)
        {
            string basePath = $"/static/Images/Patients/{id}";
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
