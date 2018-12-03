using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManager.Dtos;
using UniversityManager.Models;
using UniversityManager.ViewModels;

namespace UniversityManager.Controllers
{
    public class StudentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Students
        public ActionResult Index()
        {
            var students = _context.Students.Include(s => s.Subjects).ToList();          

            return View("List", students);
        }

        // POST: Student
        public ActionResult New()
        {
            var studentForm = new StudentFormViewModel()
            {
                Student = new Student(),
                Subjects = _context.Subjects.ToList(),
                SubjectsIds = new List<int>()
            };

            return View("StudentForm", studentForm);
        }

        public ActionResult Edit(int id)
        {
            var student = _context.Students.SingleOrDefault(s => s.Id == id);

            if (student == null)
                return HttpNotFound();

            var viewModel = new StudentFormViewModel()
            {
                Student = student,
                Subjects = _context.Subjects.ToList(),
                SubjectsIds = new List<int>()
            };

            return View("StudentForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Student student)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new StudentFormViewModel()
                {
                    Student = student,
                    Subjects = _context.Subjects.ToList()
                };

                return View("StudentForm", viewModel);
            }

            if (student.Id == 0)
                _context.Students.Add(student);
            else
            {
                var studentInDb = _context.Students.Single(s => s.Id == student.Id);

                studentInDb.Name = student.Name;
                studentInDb.Surname = student.Surname;
                studentInDb.Subjects = student.Subjects;
                studentInDb.AlbumId = student.AlbumId;
            }

            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}