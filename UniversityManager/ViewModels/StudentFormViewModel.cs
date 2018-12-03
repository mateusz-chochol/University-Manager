using System.Collections.Generic;
using UniversityManager.Models;

namespace UniversityManager.ViewModels
{
    public class StudentFormViewModel
    {
        public Student Student { get; set; }
        public List<Subject> Subjects { get; set; }
        public List<int> SubjectsIds { get; set; }
    }
}