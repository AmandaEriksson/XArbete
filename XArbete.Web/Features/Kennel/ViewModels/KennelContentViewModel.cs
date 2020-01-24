using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using XArbete.Web.User.ViewModels;

namespace XArbete.Web.Kennel.ViewModels
{
    public class KennelContentViewModel : BaseViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Namn")]
        public string Name { get; set; }

        public bool IsBreed { get; set; }

        [Display(Name="Kort beskrivning")]
        public override string Description { get; set; }

        public List<KennelContentSectionViewModel> Section { get; set; }

        [Display(Name="Länk")]
        public string Link { get; set; }

        [Display(Name = "Länk beskrivning")]
        public string LinkDescription { get; set; }

        [Display(Name = "Bild")]
        public string Img { get; set; }

        public IFormFile File { get; set; }
    }
}
