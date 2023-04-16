using AutoMapper;
using Bulutay.QuestionBankApp.Application.Dtos;
using Bulutay.QuestionBankApp.Application.Features.CQRS.Commands;
using Bulutay.QuestionBankApp.Domain.Entities;

namespace Bulutay.QuestionBankApp.Application.Mappings
{
    public class QuestionProfile : Profile
    {
        public QuestionProfile()
        {
            CreateMap<Question, QuestionListDto>().ReverseMap();
            CreateMap<Question, QuestionCreateDto>().ReverseMap();
            CreateMap<Question, QuestionUpdateDto>().ReverseMap();
            CreateMap<Question, QuestionListWithCategoryLectureUserDto>().ReverseMap();
            CreateMap<QuestionUpdateDto, UpdateQuestionCommandRequest>().ReverseMap();
            CreateMap<QuestionCreateDto, CreateQuestionCommandRequest>().ReverseMap();
        }
    }
}
