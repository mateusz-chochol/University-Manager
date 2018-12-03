using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using AutoMapper.Internal;
using AutoMapper.QueryableExtensions;
using UniversityManager.Dtos;
using UniversityManager.Models;

namespace UniversityManager.Controllers.API
{
    public class StudentsController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public StudentsController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/students
        [HttpGet]
        public IHttpActionResult GetStudents(string query = null)
        {
            var studentsQuery = _context.Students.Include(s => s.Subjects);

            if (!string.IsNullOrWhiteSpace(query))
                studentsQuery = studentsQuery
                    .Where(s => ($"{s.Name} {s.Surname} {s.AlbumId} {string.Join(", ", s.Subjects)}").Contains(query));

            var studentDtos = studentsQuery.ToList().Select(Mapper.Map<Student, StudentDto>);

            return Ok(studentDtos);
        }

        // GET /api/students/1
        [HttpGet]
        public IHttpActionResult GetStudent(int id)
        {
            var student = _context.Students.SingleOrDefault(s => s.Id == id);

            if (student == null)
                return BadRequest();

            student.Subjects = _context.Students.Single(s => s.Id == id).Subjects.ToList();

            return Ok(Mapper.Map<Student, StudentDto>(student));
        }

        // POST /api/students
        [HttpPost]
        public IHttpActionResult CreateStudent(StudentDto studentDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var student = Mapper.Map<StudentDto, Student>(studentDto);
            var subjects = new List<Subject>();

            foreach (var subject in studentDto.Subjects)
                subjects.Add(Mapper.Map<SubjectDto, Subject>(subject));

            student.Subjects = subjects;
            _context.Students.Add(student);
            _context.SaveChanges();

            studentDto.Id = student.Id;

            return Created(new Uri(Request.RequestUri + "/" + studentDto.Id), studentDto);
        }

        // PUT /api/students/1
        [HttpPut]
        public IHttpActionResult UpdateStudent(int id, StudentDto studentDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var student = _context.Students.SingleOrDefault(s => s.Id == id);

            if (student == null)
                return NotFound();

            Mapper.Map(studentDto, student);
            _context.SaveChanges();

            return Ok();
        }

        // DELETE /api/students/1
        [HttpDelete]
        public IHttpActionResult DeleteStudent(int id)
        {
            var student = _context.Students.SingleOrDefault(s => s.Id == id);

            if (student == null)
                return NotFound();

            _context.Students.Remove(student);
            _context.SaveChanges();

            return Ok();
        }
    }
}
