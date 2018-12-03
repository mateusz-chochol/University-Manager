using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UniversityManager.Models
{
    public class Test
    {
        public int Id { get; set; }
        public string Description { get; set; }

        [Required(ErrorMessage = "Please select test's subject")]
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }

        public List<Student> Students { get; set; }

        [Required(ErrorMessage = "Please enter test's weight")]
        public float? Weight { get; set; }
    }
}