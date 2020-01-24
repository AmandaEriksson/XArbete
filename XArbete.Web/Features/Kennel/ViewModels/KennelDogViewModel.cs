using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace XArbete.Web.Kennel.ViewModels
{
    public class KennelDogViewModel
    {
        public int ID { get; set; }
        [Display(Name = "Namn")]
        public string Name { get; set; }
        [Display(Name = "Ras")]
        public string Breed { get; set; }

        [Display(Name = "Ladda upp en bild")]
        public string Img { get; set; }

        public IFormFile File { get; set; }
        [Display(Name = "Kön")]
        public string Sex { get; set; }

        [Display(Name = "Om hunden")]
        public string About { get; set; }

        [Display(Name = "Födelsedatum")]
        public string DateOfBirth { get; set; }
    }
}
