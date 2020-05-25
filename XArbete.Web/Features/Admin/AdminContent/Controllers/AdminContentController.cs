using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using XArbete.Domain.Models;
using XArbete.Services.Utils.Constants;
using XArbete.Web.Features.Admin.AdminContent.ViewModels;
using XArbete.Web.Features.Admin.AdminKennel.ViewModels;
using XArbete.Web.Services.Interfaces;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace XArbete.Web.Features.Admin.AdminContent.Controllers
{
    public class AdminContentController : Controller
    {
        // GET: /<controller>/
        private IContentService _contentService;
        IContentSectionService _contentSectionService;
        IMapper _mapper;


        public AdminContentController(IContentService contentservice,
            IContentSectionService contentSectionService,
            IMapper mapper)
        {
            _contentService = contentservice;
            _contentSectionService = contentSectionService;
            _mapper = mapper;
        }

        public async Task<IActionResult> NewContentSection(int id, string title, string text)
        {
            var vm = new ContentSectionViewModel()
            {
                Title = title,
                Section = text,
                ContentId = id,
                

            };
            _contentSectionService.Create(_mapper.Map<ContentSection>(vm));
            await _contentSectionService.CommitAsync();

            var model = _contentSectionService.GetMany(a => a.ContentId == id).Select(bs => _mapper.Map<ContentSectionViewModel>(bs));
            return PartialView("_ContentSections", model);
        }
        public async Task<IActionResult> DeleteContentSection(int id)
        {
            var section = await _contentSectionService.GetSingleAsync(a => a.ContentSectionId == id);
            var model = _contentSectionService.GetMany(a => a.ContentId == section.ContentId).Select(bs => _mapper.Map<ContentSectionViewModel>(bs));

            _contentSectionService.DeleteById(id);
            await _contentSectionService.CommitAsync();

            return PartialView("_ContentSections", model);

        }

        public async Task<IActionResult> EditContent(int id, string description, string link, string linktext, IFormFile file)
        {
            var breed = _contentService.GetById(id);
            if (description != null)
            {
                breed.Description = description;
            }
            if (link != null)
            {
                breed.Link = link;
            }
            if (linktext != null)
            {
                breed.LinkDescription = linktext;
            }
            if (file != null)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), AppConstants.BreedsImagePath, file.FileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                breed.Img = file.FileName;
                await _contentService.CommitAsync();

                return Json(new { data = file.FileName });
            }
            await _contentService.CommitAsync();
            return Json(new { success = true });

        }
        public IActionResult ManageContent()
        {
            var vm = new AdminManageContentViewModel();
            vm.KennelContents = _mapper.Map<List<ContentViewModel>>(_contentService.GetAll());
            foreach (var content in vm.KennelContents)
            {
                content.Section = _mapper.Map<List<ContentSectionViewModel>>(_contentService.GetSections(content.ContentId));
            }
            vm.KennelContentSection = new ContentSectionViewModel();
            return View(vm);
        }
    }
}
