using System;
using System.Collections.Generic;
using System.Text;

namespace XArbete.Web.Models
{
    public class GuestBookComment
    {
        public int ID { get; set; }

        public string WrittenBy { get; set; }

        public string Comment { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
