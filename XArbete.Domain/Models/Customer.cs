using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace XArbete.Domain.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public string Number { get; set; }

        public string ApplicationUserID { get; set; }

        public bool IsAdmin { get; set; }

    }
}
