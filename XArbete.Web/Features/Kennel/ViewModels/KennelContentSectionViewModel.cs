using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace XArbete.Web.Kennel.ViewModels
{
    public class KennelContentSectionViewModel
    {
        public int Id { get; set; }
        public int KennelContentId { get; set; }

        [Display(Name= "Titel" )]
        public string Title { get; set; }

        [Display(Name = "Text")]
        public string Section { get; set; }
    }
}
