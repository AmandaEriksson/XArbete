using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XArbete.Web.Models
{
    public class GuestBookComment
    {
        public DateTime CreatedAt { get; set; }

        public string Name { get; set; }

        public string Comment { get; set; }
    }
}
