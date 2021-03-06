﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using XArbete.Domain.Models;

namespace XArbete.Web.Features.Kennel.ViewModels
{
    public class PuppyGroupViewModel
    {
        public int PuppyGroupId { get; set; }

        [Display(Name = "Kullens namn")]
        public string GroupName { get; set; }

        [Display(Name = "Beräknad födsel / faktiskt födsel")]
        public string DateOfBirth { get; set; }

        public DateTimeOffset DateOfBirthPicker { get; set; }

        [Display(Name = "Välj pappa till kullen")]
        public int FatherKennelDogId { get; set; }

        [Display(Name = "Välj mamma till kullen")]
        public int MotherKennelDogId { get; set; }

        public int Status { get; set; }

        public string Breed { get; set; }

        public List<PuppyViewModel> Puppies { get; set; }

        public KennelDog Mother { get; set; }
        public KennelDog Father { get; set; }
    }
}
