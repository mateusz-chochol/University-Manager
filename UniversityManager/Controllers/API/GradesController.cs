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
    public class GradesController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public GradesController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/grades
        [HttpGet]
        public IHttpActionResult GetGrades(int testId)
        {
            var grades = _context.Grades.Where(g => g.TestId == testId).ToList();
            var gradeDtos = new List<GradeDto>();

            foreach (var grade in grades)
                gradeDtos.Add(Mapper.Map<Grade, GradeDto>(grade));

            return Ok(gradeDtos);
        }
        
        // POST /api/grades
        [HttpPost]
        public IHttpActionResult CreateGrade(GradeDto gradeDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var grade = Mapper.Map<GradeDto, Grade>(gradeDto);
            _context.Grades.Add(grade);
            _context.SaveChanges();

            gradeDto.Id = grade.Id;

            return Created(new Uri(Request.RequestUri + "/" + gradeDto.Id), gradeDto);
        }

        // DELETE /api/grades/1
        [HttpDelete]
        public IHttpActionResult DeleteGrade(int id)
        {
            var grade = _context.Grades.SingleOrDefault(g => g.Id == id);

            if (grade == null)
                return NotFound();

            _context.Grades.Remove(grade);
            _context.SaveChanges();

            return Ok();
        }
    }
}
