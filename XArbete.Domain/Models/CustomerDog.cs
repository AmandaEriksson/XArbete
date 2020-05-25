using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace XArbete.Domain.Models
{
    public class CustomerDog
    {
        public int CustomerDogId { get; set; }

        [ForeignKey("Customer")]
        public int CustomerID { get; set; }

        public string Breed { get; set; }
        public string Name { get; set; }

        public string Sex { get; set; }

        public bool Kastrated { get; set; }

        public DateTime DateOfBirth { get; set; }

    }
}
