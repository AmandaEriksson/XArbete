using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace XArbete.Web.Features.Kennel.ViewModels
{
    public class PuppyViewModel
    {
        public int ID { get; set; }

        [Display( Name = "Namn")]
        public string Name { get; set; }

        [Display(Name = "Kön")]
        public string Sex { get; set; }

        [Display(Name = "Såld")]
        public bool Sold { get; set; }

        public int PuppyGroupId { get; set; }

        [Display(Name = "Ladda upp en bild på hunden")]
        public string Img { get; set; }

        public IFormFile File { get; set; }
    }
}
