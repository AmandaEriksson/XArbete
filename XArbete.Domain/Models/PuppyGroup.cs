﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XArbete.Domain.Models
{
    public class PuppyGroup
    {
        public int PuppyGroupId { get; set; }

        public int FatherKennelDogID { get; set; }

        public int MotherKennelDogId { get; set; }

        public string GroupName { get; set; }

        public int Status { get; set; }

        public DateTimeOffset DateOfBirth { get; set; }

        public string Breed { get; set; }
    }
}
