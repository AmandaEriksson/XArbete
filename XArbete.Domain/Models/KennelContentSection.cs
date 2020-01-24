using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace XArbete.Domain.Models
{
    public class KennelContentSection
    {
        public int Id { get; set; }

        [ForeignKey("KennelContent")]
        public int KennelContentId { get; set; }

        public string Title { get; set; }

        public string Section { get; set; }
    }
}
