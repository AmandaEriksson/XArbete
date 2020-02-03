using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XArbete.Domain.Models;
using XArbete.Services.Data;
using XArbete.Services.Interfaces;

namespace XArbete.Services.Services
{
    public class CourseService : ServiceBase<Course>, ICourseService
    {
        readonly ICustomerCourseService _customerCourseService;
        public CourseService(XArbeteContext context, ICustomerCourseService customercourseservice) : base(context)
        {
            _customerCourseService = customercourseservice;
        }

        public List<CustomerCourse> GetCustomersForCourse(int id)
        {
            return _customerCourseService.GetMany(a => a.CourseId == id).ToList();
        }
    }
}
