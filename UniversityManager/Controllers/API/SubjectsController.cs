using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using UniversityManager.Dtos;
using UniversityManager.Models;

namespace UniversityManager.Controllers.API
{
    public class SubjectsController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public SubjectsController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/subjects
        [HttpGet]
        public IHttpActionResult GetSubjects(string query = null)
        {
            var subjectsQuery = _context.Subjects.AsQueryable();

            if (!string.IsNullOrWhiteSpace(query))
                subjectsQuery = subjectsQuery.Where(s => s.Name.Contains(query));

            var subjectDtos = subjectsQuery.ToList().Select(Mapper.Map<Subject, SubjectDto>);

            return Ok(subjectDtos);
        }

        // GET /api/subjects/1
        [HttpGet]
        public IHttpActionResult GetSubject(int id)
        {
            var subject = _context.Subjects.SingleOrDefault(s => s.Id == id);

            if (subject == null)
                return BadRequest();

            return Ok(Mapper.Map<Subject, SubjectDto>(subject));
        }

        // POST /api/subjects
        [HttpPost]
        public IHttpActionResult CreateSubject(SubjectDto subjectDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var subject = Mapper.Map<SubjectDto, Subject>(subjectDto);
            _context.Subjects.Add(subject);
            _context.SaveChanges();

            subjectDto.Id = subject.Id;

            return Created(new Uri(Request.RequestUri + "/" + subjectDto.Id), subjectDto);
        }

        // PUT /api/subjects/1
        [HttpPut]
        public IHttpActionResult UpdateSubject(int id, SubjectDto subjectDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var subject = _context.Subjects.SingleOrDefault(s => s.Id == id);

            if (subject == null)
                return NotFound();

            Mapper.Map(subjectDto, subject);
            _context.SaveChanges();

            return Ok();
        }

        // DELETE /api/subjects/1
        [HttpDelete]
        public IHttpActionResult DeleteSubject(int id)
        {
            var subject = _context.Subjects.SingleOrDefault(s => s.Id == id);

            if (subject == null)
                return NotFound();

            _context.Subjects.Remove(subject);
            _context.SaveChanges();

            return Ok();
        }
    }
}
