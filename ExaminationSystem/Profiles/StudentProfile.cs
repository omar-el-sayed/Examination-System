using AutoMapper;
using ExaminationSystem.DTOs.Student;
using ExaminationSystem.Models;
using ExaminationSystem.ViewModels.Student;

namespace ExaminationSystem.Profiles
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            CreateMap<Student, StudentDto>();

            CreateMap<StudentDto, StudentVM>();

            CreateMap<CreateStudentVM, CreateStudentDto>();

            CreateMap<CreateStudentDto, Student>();

            CreateMap<UpdateStudentVM, UpdateStudentDto>();

            CreateMap<UpdateStudentDto, Student>();
        }
    }
}
