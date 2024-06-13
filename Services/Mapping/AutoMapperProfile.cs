using AutoMapper;
using Domain.Entities;
using Services.Shared.DTO.Lesson;
using Services.Shared.DTO.Student;

namespace Services.Mapping;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<CreateStudentDto, Student>();
        CreateMap<Student, StudentDto>();
        CreateMap<StudentDto, Student>();

        CreateMap<CreateLessonDto, Lesson>();
        CreateMap<Lesson, LessonDto>();
        CreateMap<LessonDto, Lesson>();
        CreateMap<LessonType, LessonTypeDto>();
        CreateMap<LessonTypeDto, LessonType>();
        CreateMap<LessonStateType, LessonStateTypeDto>();
        CreateMap<LessonStateTypeDto, LessonStateType>();
    }
}