using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using XArbete.Services.Interfaces;
using XArbete.Web.Features.Course.ViewModels;
using XArbete.Web.Features.Customer.ViewModels;
using XArbete.Web.Utils.AutoMapper;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace XArbete.Web.Features.Admin.AdminCourse.Controllers
{
    public class AdminCourseController : Controller
    {
        ICourseService _courseService;
        IMapper _mapper;
        public AdminCourseController(ICourseService courseservice, IMapper mapper)
        {
            _courseService = courseservice;
            _mapper = mapper;
        }
        // GET: /<controller>/
        public IActionResult ManageCourses()
        {
            var vm = new CourseListViewModel();
            vm.ActiveCourses = GetCourses().Where(a => a.Date >= DateTime.Now || a.Date.AddDays(7 * a.RepeatingForWeeks) >= DateTime.Now).ToList();
            vm.PreviousCourses = GetCourses().Where(a => a.Date < DateTime.Now && a.Date.AddDays(7 * a.RepeatingForWeeks) < DateTime.Now).ToList();
            return View(vm);
        }
        List<CourseViewModel> GetCourses()
        {
            var model = _mapper.Map<List<CourseViewModel>>(_courseService.GetAll());
            foreach (var course in model)
            {
                course.Participants = _mapper.Map<List<CustomerViewModel>>(_courseService.GetCustomersForCourse(course.Id));
            }
            return model;
        }
  

        public async Task<IActionResult> NewCourse(CourseViewModel vm)
        {
            vm.Date = vm.DatePicker.DateTime;
            _courseService.Create(_mapper.Map<XArbete.Domain.Models.Course>(vm));
            await _courseService.CommitAsync();
            var model = GetCourses().Where(a => a.Date >= DateTime.Now || a.Date.AddDays(7 * a.RepeatingForWeeks) >= DateTime.Now).ToList();

            return PartialView("_Courses", model);
        }
        public async Task<IActionResult> DeleteCourse(int id)
        {
            _courseService.DeleteById(id);
            await _courseService.CommitAsync();
            var model = GetCourses().Where(a => a.Date >= DateTime.Now || a.Date.AddDays(7 * a.RepeatingForWeeks) >= DateTime.Now).ToList();

            return PartialView("_Courses", model );

        }
    }
}
