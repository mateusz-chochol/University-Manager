using System.ComponentModel.DataAnnotations;
using UniversityManager.Models;

namespace UniversityManager.Dtos
{
    public class GradeDto
    {
        public int Id { get; set; }

        [Required]
        [RegularExpression("^[2-5]|([2-5].[0-9])$")]
        public float? Value { get; set; }

        public int TestId { get; set; }
        public TestDto Test { get; set; }

        public int StudentId { get; set; }
        public StudentDto Student { get; set; }
    }
}