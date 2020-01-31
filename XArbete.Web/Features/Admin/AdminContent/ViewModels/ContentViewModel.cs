using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using XArbete.Web.Features.User.ViewModels;

namespace XArbete.Web.Features.Admin.AdminContent.ViewModels
{
    public class ContentViewModel : BaseViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Namn")]
        public string Name { get; set; }

        public string Type { get; set; }

        [Display(Name="Kort beskrivning")]
        public override string Description { get; set; }

        public List<ContentSectionViewModel> Section { get; set; }

        [Display(Name="Länk")]
        public string Link { get; set; }

        [Display(Name = "Länk beskrivning")]
        public string LinkDescription { get; set; }

        [Display(Name = "Bild")]
        public string Img { get; set; }

        public IFormFile File { get; set; }
    }
}
