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
    public class TestsController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public TestsController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/tests
        [HttpGet]
        public IHttpActionResult GetTests(int subjectId)
        {
            var tests = _context.Subjects.Single(s => s.Id == subjectId).Tests.ToList();
            var testsDto = new List<TestDto>();

            foreach (var test in tests)
                testsDto.Add(Mapper.Map<Test, TestDto>(test));

            return Ok(testsDto);
        }

        // GET /api/tests/1
        [HttpGet]
        public IHttpActionResult GetTest(int id, int subjectId)
        {
            var test = _context.Subjects.Single(s => s.Id == subjectId).Tests.SingleOrDefault(t => t.Id == id);

            if (test == null)
                return NotFound();

            return Ok(Mapper.Map<Test, TestDto>(test));
        }

        // POST /api/tests
        [HttpPost]
        public IHttpActionResult CreateTest(TestDto testDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var test = Mapper.Map<TestDto, Test>(testDto);
            _context.Tests.Add(test);
            _context.SaveChanges();

            testDto.Id = test.Id;

            return Created(new Uri(Request.RequestUri + "/" + testDto.Id), testDto);
        }

        // PUT /api/tests/1
        [HttpPut]
        public IHttpActionResult UpdateTest(int id, TestDto testDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var test = _context.Tests.SingleOrDefault(t => t.Id == id);

            if (test == null)
                return NotFound();

            Mapper.Map(testDto, test);
            _context.SaveChanges();

            return Ok();
        }

        // DELETE /api/tests/1
        [HttpDelete]
        public IHttpActionResult DeleteTest(int id)
        {
            var test = _context.Tests.SingleOrDefault(t => t.Id == id);

            if (test == null)
                return NotFound();

            _context.Tests.Remove(test);
            _context.SaveChanges();

            return Ok();
        }
    }
}
