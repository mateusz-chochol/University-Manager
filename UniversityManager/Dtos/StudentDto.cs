using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using UniversityManager.Models;

namespace UniversityManager.Dtos
{
    public class StudentDto
    {
        public int Id { get; set; }

        [Required]
        [RegularExpression("^[A-Z][a-z]*$")]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [RegularExpression("^[A-Z][a-z]*$")]
        [StringLength(255)]
        public string Surname { get; set; }

        [RegularExpression("^[A-Z]/[0-9]{1,6}$")]
        public string AlbumId { get; set; }

        public List<SubjectDto> Subjects { get; set; }
        public List<GradeDto> Grades { get; set; }
    }
}