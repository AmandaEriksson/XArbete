using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace XArbete.Web.Features.Admin.AdminContent.ViewModels
{
    public class ContentSectionViewModel
    {
        public int ContentSectionId { get; set; }
        public int ContentId { get; set; }

        [Display(Name= "Titel" )]
        public string Title { get; set; }

        [Display(Name = "Text")]
        public string Section { get; set; }
    }
}
