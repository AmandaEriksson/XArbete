﻿using System;
using System.Collections.Generic;
using System.Text;
using XArbete.Domain.Models;
using XArbete.Web.Services.Interfaces;

namespace XArbete.Services.Interfaces
{
    public interface ICourseService : IServiceBase<Course>
    {
        List<CustomerCourse> GetCustomersForCourse(int id);
    }
}
