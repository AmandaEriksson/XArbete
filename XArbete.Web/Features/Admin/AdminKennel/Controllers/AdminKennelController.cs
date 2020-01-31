using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using XArbete.Domain.Models;
using XArbete.Services.Utils.Constants;
using XArbete.Web.Features.Admin.AdminKennel.ViewModels;
using XArbete.Web.Features.Kennel.ViewModels;
using XArbete.Web.Services.Interfaces;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace XArbete.Web.Features.Admin.AdminKennel.Controllers
{
    public class AdminKennelController : Controller
    {
        IToastNotification _toastNotification;
        IKennelDogService _kennelDogService;
        IPuppyGroupService _puppyGroupService;
        IPuppyService _puppyService;
        IMapper _mapper;


        public AdminKennelController(IToastNotification toastNotification, 
            IKennelDogService kennelDogService,
            IPuppyGroupService puppyGroupService,
            IPuppyService puppyservice,IMapper mapper)
        {
            _toastNotification = toastNotification;
            _kennelDogService = kennelDogService;
            _puppyGroupService = puppyGroupService;
            _puppyService = puppyservice;
            _mapper = mapper;
        }
        // GET: /<controller>/
        #region Kennel related
        public IActionResult ManageKennel()
        {
            var vm = GetAdminKennelViewModel();
            return View("ManageKennel", vm);
        }
        AdminManageKennelViewModel GetAdminKennelViewModel()
        {
            var vm = new AdminManageKennelViewModel();

            vm.Dogs = _kennelDogService.GetAll().Select(d => _mapper.Map<KennelDogViewModel>(d));
            vm.Dog = new KennelDogViewModel();
            vm.PuppyGroups = _puppyGroupService.GetAll().Select(pg => _mapper.Map<PuppyGroupViewModel>(pg));
            vm.PuppyGroup = new PuppyGroupViewModel();
            vm.Puppies = _puppyService.GetAll().Select(p => _mapper.Map<PuppyViewModel>(p));
            vm.Puppy = new PuppyViewModel();
            //vm.KennelContents = _kennelContentService.GetAll().Select(b => _mapper.Map<KennelContentViewModel>(b));
            //vm.KennelContentSections = _kennelContentSectionService.GetAll().Select(bs => _mapper.Map<KennelContentSectionViewModel>(bs));
            //vm.KennelContentSection = new KennelContentSectionViewModel();
            return vm;
        }
        #endregion

        #region KennelDogs related
        public IActionResult KennelDogs()
        {
            var vm = _kennelDogService.GetAll().Select(kd => _mapper.Map<KennelDogViewModel>(kd));
            return PartialView("_KennelDogsTab", vm);
        }
        [HttpPost]
        public async Task<IActionResult> NewKennelDog(KennelDogViewModel model, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), AppConstants.KennelDogsImagesPath, file.FileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                model.Img = file.FileName;
                var dog = _mapper.Map<KennelDog>(model);
                _kennelDogService.Create(dog);
                await _kennelDogService.CommitAsync();
            }

            return RedirectToAction("KennelDogs");
        }
        public async Task<IActionResult> DeleteKennelDog(int id)
        {
            _kennelDogService.DeleteById(id);
            await _kennelDogService.CommitAsync();

            return RedirectToAction("KennelDogs");
        }


        public async Task<IActionResult> EditDog(int id, string dogname, string about)
        {
            _kennelDogService.Edit(id, dogname, about);
            await _kennelDogService.CommitAsync();

            return Json(new { success = true });
        }

        #endregion
        #region Puppies related
        [HttpPost]
        public async Task<IActionResult> NewPuppy(PuppyViewModel model)
        {
            if (model.File != null)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), AppConstants.KennelPuppiesImagesPath, model.File.FileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await model.File.CopyToAsync(stream);
                }
                model.Img = model.File.FileName;
            }
            var puppy = _mapper.Map<Puppy>(model);
            _puppyService.Create(puppy);
            await _puppyService.CommitAsync();

            return RedirectToAction("PuppyGroupPuppies", new { id = puppy.PuppyGroupId });
        }

        public async Task<IActionResult> EditPuppy(int id, string name)
        {
            _puppyService.Edit(id, name);
            await _puppyService.CommitAsync();

            return Json(new { success = true });
        }

        public async Task<IActionResult> DeletePuppy(int id)
        {
            var pupGroupID = _puppyService.GetById(id).PuppyGroupId;
            _puppyService.DeleteById(id);
            await _puppyService.CommitAsync();

            return RedirectToAction("PuppyGroupPuppies", new { id = pupGroupID });

        }

        //public async Task<IActionResult> ChangePuppyStatus(int id, bool status)
        //{
        //    _puppyService.ChangeStatus(id, status);
        //    await _puppyService.CommitAsync();
        //    _toastNotification.AddSuccessToastMessage($"Valp med id {id} ändrad status");
        //    return Json(new { success = true });
        //}

        #endregion
        #region PuppyGroups related
        public IActionResult PuppyGroupPuppies(int id)
        {
            var puppies = _puppyService.GetMany(a => a.PuppyGroupId == id);
            var mod = puppies.Select(p => _mapper.Map<PuppyViewModel>(p));
            return PartialView("_PuppuGroupPuppies", mod);
        }


        public IActionResult PuppyGroups()
        {
            var vm = GetAdminKennelViewModel();
            return PartialView("_PuppyGroupsTab", vm);
        }

        public async Task<IActionResult> NewPuppyGroup(AdminManageKennelViewModel model)
        {
            var puppy = _mapper.Map<PuppyGroup>(model.PuppyGroup);
            _puppyGroupService.Create(puppy);
            await _puppyGroupService.CommitAsync();

            return RedirectToAction("PuppyGroups");
        }

        public async Task<IActionResult> DeletePuppyGroup(int id)
        {
            _puppyGroupService.DeleteById(id);
            await _puppyGroupService.CommitAsync();

            return RedirectToAction("PuppyGroups");
        }

        // default fix, if value isn't in the request it's because status is changed to Active (value 1) 
        public async Task<IActionResult> ChangePuppyGroupStatus(int id, int status = 1, string newBornDate = null)
        {
            var puppyGroup = _puppyGroupService.GetSingle(a => a.ID == id);
            if (newBornDate != null)
            {
                puppyGroup.DateOfBirth = DateTimeOffset.Parse(newBornDate);
                await _puppyGroupService.CommitAsync();
            }
            _puppyGroupService.ChangeStatus(puppyGroup, status);
            await _puppyGroupService.CommitAsync();
            _toastNotification.AddSuccessToastMessage($"Status ändrad för valpkull med id {id}");

            return RedirectToAction("PuppyGroups");
        }
        public async Task<IActionResult> ChangePuppyStatus(int id, bool status)
        {
            _puppyService.ChangeStatus(id, status);
            await _puppyService.CommitAsync();
            _toastNotification.AddSuccessToastMessage($"Valp med id {id} ändrad status");
            return Json(new { success = true });
        }

        #endregion
        #region Breeds related

        #endregion
    }
}
