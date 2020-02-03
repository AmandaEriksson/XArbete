using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace XArbete.Domain.Models
{
    public class CustomerCourse
    {
        public int Id { get; set; }
        [ForeignKey("Course")]
        public int CourseId { get; set; }

        [ForeignKey("Customer")]
        public int CustomerId { get; set; }

        [ForeignKey("CustomerDog")]
        public int DogId { get; set; }
    }
}
