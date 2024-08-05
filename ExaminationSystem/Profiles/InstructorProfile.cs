using AutoMapper;
using ExaminationSystem.DTOs.Instructor;
using ExaminationSystem.Models;
using ExaminationSystem.ViewModels.Instructor;

namespace ExaminationSystem.Profiles
{
    public class InstructorProfile : Profile
    {
        public InstructorProfile()
        {
            CreateMap<Instructor, InstructorDto>();

            CreateMap<InstructorDto, InstructorVM>();

            CreateMap<CreateInstructorVM, CreateInstructorDto>();

            CreateMap<CreateInstructorDto, Instructor>();

            CreateMap<UpdateInstructorVM, UpdateInstructorDto>();

            CreateMap<UpdateInstructorDto, Instructor>();
        }
    }
}
