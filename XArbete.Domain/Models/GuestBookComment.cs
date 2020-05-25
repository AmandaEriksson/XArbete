using System;
using System.Collections.Generic;
using System.Text;

namespace XArbete.Domain.Models
{
    public class GuestBookComment
    {
        public int GuestBookCommentId { get; set; }

        public string WrittenBy { get; set; }

        public string Comment { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
