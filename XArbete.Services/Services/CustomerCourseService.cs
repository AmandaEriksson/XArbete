using System;
using System.Collections.Generic;
using System.Text;
using XArbete.Domain.Models;
using XArbete.Services.Data;
using XArbete.Services.Interfaces;

namespace XArbete.Services.Services
{
    public class CustomerCourseService : ServiceBase<CustomerCourse>, ICustomerCourseService
    {
        public CustomerCourseService(XArbeteContext context) : base(context)
        {
        }
    }
}
