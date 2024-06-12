using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PatientManagerApp.Core.Application.Interfaces.Services;
using PatientManagerApp.Core.Application.ViewModels.LaboratoryResult;
using PatientManagerApp.Core.Application.ViewModels.User;
using WebApp.PatientManagerApp.Middlewares;
using PatientManagerApp.Core.Application.Helpers;
using PatientManagerApp.Core.Application.Services;

public class LaboratoryResultController : Controller
{
    private readonly ILaboratoryResultService _laboratoryResultService;
    private readonly IPatientService _patientService;
    private readonly ILaboratoryTestService _laboratoryTestService;
    private readonly ValidateUserSession _validateUserSession;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly UserViewModel _userViewModel;

    public LaboratoryResultController(ILaboratoryResultService laboratoryResultService, IPatientService patientService, ILaboratoryTestService laboratoryTestService , ValidateUserSession validateUserSession, IHttpContextAccessor httpContextAccessor)
    {
        _laboratoryResultService = laboratoryResultService;
        _patientService = patientService;
        _validateUserSession = validateUserSession;
        _httpContextAccessor = httpContextAccessor;
        _laboratoryTestService = laboratoryTestService;
        _userViewModel = _httpContextAccessor.HttpContext.Session.Get<UserViewModel>("user");
    }

    public async Task<IActionResult> Index()
    {
        if (!_validateUserSession.HasUser())
        {
            return RedirectToRoute(new { controller = "User", action = "Login" });
        }

        List<LaboratoryResultViewModel> laboratoryResultViewModelList = await _laboratoryResultService.GetAllViewModelAsync();
        return View(laboratoryResultViewModelList);
    }

    public async Task<IActionResult> Save()
    {
        SaveLaboratoryResultViewModel saveLaboratoryResultViewModel = new();

        if (!_validateUserSession.HasUser())
        {
            return RedirectToRoute(new { controller = "User", action = "Login" });
        }

        var patients = await _patientService.GetAllViewModelAsync();
        ViewBag.Patients = patients.Select(p => new SelectListItem
        {
            Value = p.Id.ToString(),
            Text = p.Name
        }).ToList();

        var tests = await _laboratoryTestService.GetAllViewModelAsync();
        ViewBag.LaboratoryTests = tests.Select(t => new SelectListItem
        {
            Value = t.Id.ToString(),
            Text = t.Name
        }).ToList();

        return View(saveLaboratoryResultViewModel);
    }

    [HttpPost]
    public async Task<IActionResult> Save(SaveLaboratoryResultViewModel saveLaboratoryResultViewModel)
    {
        if (!ModelState.IsValid)
        {
            var patients = await _patientService.GetAllViewModelAsync();
            ViewBag.Patients = patients.Select(p => new SelectListItem
            {
                Value = p.Id.ToString(),
                Text = p.Name
            }).ToList();

            var tests = await _laboratoryTestService.GetAllViewModelAsync();
            ViewBag.LaboratoryTests = tests.Select(t => new SelectListItem
            {
                Value = t.Id.ToString(),
                Text = t.Name
            }).ToList();

            return View(saveLaboratoryResultViewModel);
        }

        saveLaboratoryResultViewModel.ClinicId = _userViewModel.ClinicId;

        await _laboratoryResultService.Insert(saveLaboratoryResultViewModel);
        return RedirectToRoute(new { controller = "Home", action = "Index" });
    }

    public async Task<IActionResult> Update(int id)
    {
        var saveLaboratoryResultViewModel = await _laboratoryResultService.GetByIdCreateViewModel(id);

        var patients = await _patientService.GetAllViewModelAsync();
        ViewBag.Patients = patients.Select(p => new SelectListItem
        {
            Value = p.Id.ToString(),
            Text = p.Name
        }).ToList();

        var tests = await _laboratoryTestService.GetAllViewModelAsync();
        ViewBag.LaboratoryTests = tests.Select(t => new SelectListItem
        {
            Value = t.Id.ToString(),
            Text = t.Name
        }).ToList();

        return View("Save", saveLaboratoryResultViewModel);
    }

    [HttpPost]
    public async Task<IActionResult> Update(SaveLaboratoryResultViewModel vm)
    {
        if (!ModelState.IsValid)
        {
            var patients = await _patientService.GetAllViewModelAsync();
            ViewBag.Patients = patients.Select(p => new SelectListItem
            {
                Value = p.Id.ToString(),
                Text = p.Name
            }).ToList();

            var tests = await _laboratoryTestService.GetAllViewModelAsync();
            ViewBag.LaboratoryTests = tests.Select(t => new SelectListItem
            {
                Value = t.Id.ToString(),
                Text = t.Name
            }).ToList();

            return View(vm);
        }

        await _laboratoryResultService.Update(vm);
        return RedirectToAction("Index");
    }

    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        await _laboratoryResultService.Delete(id);
        return RedirectToAction("Index");
    }
}
