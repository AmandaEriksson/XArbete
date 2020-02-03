using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XArbete.Services.Interfaces;
using XArbete.Web.Features.Course.ViewModels;
using XArbete.Web.Features.Customer.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace XArbete.Web.Features.Course.Controllers
{
    public class CourseController : Controller
    {
        private ICourseService _courseService;
        private IMapper _mapper;

        public CourseController(ICourseService courseservice, IMapper mapper)
        {
            _courseService = courseservice;
            _mapper = mapper;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            var model = _courseService.GetAll();
            return View(model);
        }

       
    }
}
