using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XArbete.Web.Models;

namespace XArbete.Web.ViewModels
{
    public class GuestBookViewModel
    {
        public IEnumerable<GuestBookComment> Comments { get; set; }

        public GuestBookComment Comment { get; set; }
    }
}
