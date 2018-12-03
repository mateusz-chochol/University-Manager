using AutoMapper;
using UniversityManager.Dtos;
using UniversityManager.Models;

namespace UniversityManager
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Student, StudentDto>();
            Mapper.CreateMap<StudentDto, Student>()
                .ForMember(s => s.Id, opt => opt.Ignore())
                .ForMember(s => s.Grades, opt => opt.Ignore());

            Mapper.CreateMap<Subject, SubjectDto>();
            Mapper.CreateMap<SubjectDto, Subject>()
                .ForMember(s => s.Id, opt => opt.Ignore())
                .ForMember(s => s.Tests, opt => opt.Ignore())
                .ForMember(s => s.Students, opt => opt.Ignore());

            Mapper.CreateMap<Test, TestDto>();
            Mapper.CreateMap<TestDto, Test>()
                .ForMember(t => t.Id, opt => opt.Ignore())
                .ForMember(t => t.Students, opt => opt.Ignore());

            Mapper.CreateMap<Grade, GradeDto>();
            Mapper.CreateMap<GradeDto, Grade>()
                .ForMember(g => g.Id, opt => opt.Ignore());
        }
    }
}