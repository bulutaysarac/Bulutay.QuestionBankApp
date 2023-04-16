using AutoMapper;
using Bulutay.QuestionBankApp.Application.Dtos;
using Bulutay.QuestionBankApp.Application.Features.CQRS.Commands;
using Bulutay.QuestionBankApp.Domain.Entities;

namespace Bulutay.QuestionBankApp.Application.Mappings
{
    public class LectureProfile : Profile
    {
        public LectureProfile()
        {
            CreateMap<Lecture, LectureCreateDto>().ReverseMap();
            CreateMap<Lecture, LectureListDto>().ReverseMap();
            CreateMap<Lecture, LectureUpdateDto>().ReverseMap();
            CreateMap<Lecture, LectureListWithDepartmentDto>().ReverseMap();
            CreateMap<LectureCreateDto, CreateLectureCommandRequest>().ReverseMap();
            CreateMap<LectureUpdateDto, UpdateLectureCommandRequest>().ReverseMap();
        }
    }
}
