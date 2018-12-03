using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UniversityManager.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter student's name")]
        [RegularExpression("^[A-Z][a-z]*$", ErrorMessage = "Please enter valid student's name (has to start with uppercase letter and can contain only letters)")]
        [StringLength(255)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter student's surname")]
        [RegularExpression("^[A-Z][a-z]*$", ErrorMessage = "Please enter valid student's surname (has to start with uppercase letter and can contain only letters)")]
        [StringLength(255)]
        public string Surname { get; set; }
        
        [RegularExpression("^[A-Z]/[0-9]{1,6}$", ErrorMessage = "Please enter valid student's album ID (has to start with a uppercase letter followed by a '/' which is then followed by a string of up to 6 numbers")]
        [Display(Name = "Album ID")]
        public string AlbumId { get; set; }
        
        public List<Subject> Subjects { get; set; }
        public List<Grade> Grades { get; set; }
    }
}