using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using UniversityManager.Models;

namespace UniversityManager.Dtos
{
    public class TestDto
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public int SubjectId { get; set; }
        public SubjectDto Subject { get; set; }

        public List<Student> Students { get; set; }

        [Required]
        public float? Weight { get; set; }
    }
}