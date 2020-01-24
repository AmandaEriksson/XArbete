using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using XArbete.Service.Utils.Constants;
using XArbete.Web.Kennel.ViewModels;
using XArbete.Web.Services.Interfaces;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace XArbete.Web.Kennel.Controllers
{
    public class KennelController : Controller
    {
        private IKennelDogService _kennelDogService;
        private IPuppyGroupService _puppyGroupService;
        private IPuppyService _puppyService;
        private IKennelContentService _breedService;
        IKennelContentSectionService _breedSectionService;
        IMapper _mapper;
        public KennelController(IKennelDogService kennelDogService,
            IMapper mapper,
            IPuppyGroupService puppygroupservice,
            IPuppyService puppyservice,
            IKennelContentService breedservice,
            IKennelContentSectionService breedsection)
        {
            _kennelDogService = kennelDogService;
            _puppyGroupService = puppygroupservice;
            _puppyService = puppyservice;
            _mapper = mapper;
            _breedService = breedservice;
            _breedSectionService = breedsection;
        }
        // GET: /<controller>/
        public IActionResult AboutDogs()
        {
            var vm = new KennelContentListViewModel();
            vm.KennelContents = _breedService.GetMany(a => a.IsBreed).Select(a => _mapper.Map<KennelContentViewModel>(a)).ToList();
            foreach (var breed in vm.KennelContents)
            {
                breed.Section = _breedSectionService.GetMany(a => a.KennelContentId == breed.Id).Select(a => _mapper.Map<KennelContentSectionViewModel>(a)).ToList();
            }

            return View(vm);
        }
        public IActionResult BuyPuppy()
        {
            var vm = new KennelContentListViewModel();
            vm.KennelContents = _breedService.GetMany(a => !a.IsBreed).Select(a => _mapper.Map<KennelContentViewModel>(a)).ToList();
            foreach (var tab in vm.KennelContents)
            {
                tab.Section = _breedSectionService.GetMany(a => a.KennelContentId == tab.Id).Select(a => _mapper.Map<KennelContentSectionViewModel>(a)).ToList();
            }
            return View(vm);
        }
        public IActionResult EarlierPuppies()
        {
            var model = GetPuppyGroups(PuppyGroupStatusConstants.Passed);
            return View(model);
        }
        public IActionResult OurDogs()
        {
            var model = new KennelDogsViewModel()
            {
                Dogs = _kennelDogService.GetAll().Select(a => _mapper.Map<KennelDogViewModel>(a))
            };


            return View(model);
        }
        public IActionResult PlannedPuppies()
        {
            var model = GetPuppyGroups(PuppyGroupStatusConstants.Planned);
            return View(model);
        }
        public IActionResult ActivePuppies()
        {
            var model = GetPuppyGroups(PuppyGroupStatusConstants.Active);
            return View(model);
        }

        PuppyGroupsViewModel GetPuppyGroups(int statusCode)
        {
            var puppygroups = _puppyGroupService.GetMany(a => a.Status == statusCode);

            var model = new PuppyGroupsViewModel();
            model.PuppyGroups = puppygroups.Select(a => _mapper.Map<PuppyGroupViewModel>(a)).ToList();
            foreach (var group in model.PuppyGroups)
            {
                group.Puppies = _puppyService.GetMany(a => a.PuppyGroupId == group.ID).Select(a => _mapper.Map<PuppyViewModel>(a)).ToList();
                group.Mother = _kennelDogService.GetSingle(a => a.ID == group.MotherID);
                group.Father = _kennelDogService.GetSingle(a => a.ID == group.FatherID);
                group.Breed = _kennelDogService.GetSingle(a => a.ID == group.FatherID).Breed;
            }
            return model;
        }
    }
}
