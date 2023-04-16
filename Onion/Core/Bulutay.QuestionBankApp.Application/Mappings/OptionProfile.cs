using AutoMapper;
using Bulutay.QuestionBankApp.Application.Dtos;
using Bulutay.QuestionBankApp.Application.Features.CQRS.Commands;
using Bulutay.QuestionBankApp.Domain.Entities;

namespace Bulutay.QuestionBankApp.Application.Mappings
{
    public class OptionProfile : Profile
    {
        public OptionProfile()
        {
            CreateMap<Option, OptionCreateDto>().ReverseMap();
            CreateMap<Option, OptionListDto>().ReverseMap();
            CreateMap<Option, OptionUpdateDto>().ReverseMap();
            CreateMap<OptionCreateDto, CreateOptionCommandRequest>().ReverseMap();
            CreateMap<OptionUpdateDto, UpdateOptionCommandRequest>().ReverseMap();
        }
    }
}
