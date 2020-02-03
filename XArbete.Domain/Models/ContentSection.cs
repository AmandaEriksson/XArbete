using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace XArbete.Domain.Models
{
    public class ContentSection
    {
        public int Id { get; set; }
        [ForeignKey("Contents")]
        public int ContentId { get; set; }

        public string Title { get; set; }

        public string Section { get; set; }
    }
}
