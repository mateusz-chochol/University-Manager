using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManager.Models;

namespace UniversityManager.Controllers
{
    public class SubjectsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SubjectsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Subjects
        public ActionResult Index()
        {
            var subjects = _context.Subjects.Include(s => s.Tests).Include(s => s.Students).ToList();          

            return View("List", subjects);
        }

        public ActionResult New()
        {
            var subject = new Subject();

            return View("SubjectForm", subject);
        }

        public ActionResult Edit(int id)
        {
            var subject = _context.Subjects.SingleOrDefault(s => s.Id == id);

            if (subject == null)
                return HttpNotFound();

            return View("SubjectForm", subject);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Subject subject)
        {
            if (!ModelState.IsValid)
                return View("SubjectForm", subject);

            if (subject.Id == 0)
                _context.Subjects.Add(subject);
            else
            {
                var subjectInDb = _context.Subjects.Single(s => s.Id == subject.Id);

                subjectInDb.Name = subject.Name;
            }

            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}