using System.ComponentModel.DataAnnotations;

namespace UniversityManager.Models
{
    public class Grade
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter valid grade (2.0-5.0)")]
        [RegularExpression("^[2-5]|([2-5].[0-9])$")]
        public float? Value { get; set; }

        [Required(ErrorMessage = "Please select where is this grade comming from")]
        public int TestId { get; set; }
        public Test Test { get; set; }

        [Required(ErrorMessage = "Please select student this grade should be assigned to")]
        public int StudentId { get; set; }
        public Student Student { get; set; }
    }
}