using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XArbete.Web.Features.User.ViewModels;

namespace XArbete.Web.Features.Course.ViewModels
{
    public class CourseListViewModel : BaseViewModel
    {
        public List<CourseViewModel> ActiveCourses { get; set; }
        public List<CourseViewModel> PreviousCourses { get; set; }

        public CourseViewModel Course { get; set; }
    }
}
