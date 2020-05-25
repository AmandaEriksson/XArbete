using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace XArbete.Domain.Models
{
    public class ContentSection
    {
        public int ContentSectionId { get; set; }
        public int ContentId { get; set; }
        [ForeignKey("Contents")]

        public string Title { get; set; }

        public string Section { get; set; }
    }
}
