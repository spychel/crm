using AutoMapper;
using Domain.Entities;

namespace Services;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Student, StudentDto>();
        CreateMap<CreateStudentDto, Student>();
        CreateMap<StudentDto, Student>();
    }
}