﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using XArbete.Service.Utils.Constants;
using XArbete.Services.Utils.Constants;
using XArbete.Web.Features.Admin.AdminContent.ViewModels;
using XArbete.Web.Features.Kennel.ViewModels;
using XArbete.Web.Services.Interfaces;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace XArbete.Web.Features.Kennel.Controllers
{
    public class KennelController : Controller
    {
        private IKennelDogService _kennelDogService;
        private IPuppyGroupService _puppyGroupService;
        private IPuppyService _puppyService;
        private IContentService _contentService;
        IMapper _mapper;
        public KennelController(IKennelDogService kennelDogService,
            IMapper mapper,
            IPuppyGroupService puppygroupservice,
            IPuppyService puppyservice,
            IContentService contentservice)
        {
            _kennelDogService = kennelDogService;
            _puppyGroupService = puppygroupservice;
            _puppyService = puppyservice;
            _mapper = mapper;
            _contentService = contentservice;
        }
        // GET: /<controller>/
        public IActionResult AboutDogs()
        {
            var vm = new ContentListViewModel();
            // FIX HERE
            vm.KennelContents = _mapper.Map<List<ContentViewModel>>(_contentService.GetMany(a => a.Type == ContentConstants.BreedContent));
            foreach (var tab in vm.KennelContents)
            {
                tab.Section = _contentService.GetSections(tab.ContentId).Select(a => _mapper.Map<ContentSectionViewModel>(a)).ToList();
            }

            return View(vm);
        }
        public IActionResult PuppyGroups()
        {
            var model = new PuppyGroupsViewModel();
            model.PlannedPuppyGroups = GetPuppyGroups(PuppyGroupStatusConstants.Planned);
            model.ActivePuppyGroups = GetPuppyGroups(PuppyGroupStatusConstants.Active);
            model.PassedPuppyGroups = GetPuppyGroups(PuppyGroupStatusConstants.Passed);

            return View(model);
        }
        public IActionResult BuyPuppy()
        {
            var vm = new ContentListViewModel();
            vm.KennelContents = _mapper.Map<List<ContentViewModel>>(_contentService.GetMany(a => ContentConstants.BuyPuppyContents.Contains(a.Type)));
            foreach (var tab in vm.KennelContents)
            {
                tab.Section = _contentService.GetSections(tab.ContentId).Select(a => _mapper.Map<ContentSectionViewModel>(a)).ToList();
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

        List<PuppyGroupViewModel> GetPuppyGroups(int statusCode)
        {
            var puppygroups = _puppyGroupService.GetMany(a => a.Status == statusCode);

            var model = new PuppyGroupsViewModel();
            var vm = puppygroups.Select(a => _mapper.Map<PuppyGroupViewModel>(a)).ToList();
            foreach (var group in vm)
            {
                group.Puppies = _puppyService.GetMany(a => a.PuppyGroupId == group.PuppyGroupId).Select(a => _mapper.Map<PuppyViewModel>(a)).ToList();
                group.Mother = _kennelDogService.GetSingle(a => a.KennelDogId == group.MotherKennelDogId);
                group.Father = _kennelDogService.GetSingle(a => a.KennelDogId == group.FatherKennelDogId);
                group.Breed = _kennelDogService.GetSingle(a => a.KennelDogId == group.FatherKennelDogId).Breed;
            }
            return vm;
        }


    }
}
