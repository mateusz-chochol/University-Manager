using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UniversityManager.Models
{
    public class Subject
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter subject's name")]
        [StringLength(255)]
        public string Name { get; set; }

        public List<Student> Students { get; set; }
        public List<Test> Tests { get; set; }
    }
}