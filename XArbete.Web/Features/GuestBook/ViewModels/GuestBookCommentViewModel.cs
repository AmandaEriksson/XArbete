using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace XArbete.Web.Features.GuestBook.ViewModels
{
    public class GuestBookCommentViewModel
    {
        public int ID { get; set; }

        [Display(Name = "Ditt namn")]
        public string WrittenBy { get; set; }

        [Display(Name = "Skriv din kommentar")]
        public string Comment { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
