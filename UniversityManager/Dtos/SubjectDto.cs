using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using UniversityManager.Models;

namespace UniversityManager.Dtos
{
    public class SubjectDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        
        public List<StudentDto> Students { get; set; }
        public List<TestDto> Tests { get; set; }
    }
}