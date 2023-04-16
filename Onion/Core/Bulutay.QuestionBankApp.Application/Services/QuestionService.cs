using AutoMapper;
using Bulutay.QuestionBankApp.Application.Common;
using Bulutay.QuestionBankApp.Application.Dtos;
using Bulutay.QuestionBankApp.Application.Enums;
using Bulutay.QuestionBankApp.Application.Interfaces;
using Bulutay.QuestionBankApp.Domain.Entities;
using FluentValidation;

namespace Bulutay.QuestionBankApp.Application.Services
{
    public class QuestionService : Service<QuestionCreateDto, QuestionUpdateDto, QuestionListDto, Question>, IQuestionService
    {
        private readonly IValidator<QuestionCreateDto> _createDtoValidator;
        private readonly IValidator<QuestionUpdateDto> _updateDtoValidator;
        private readonly IQuestionRepository _questionRepository;
        private readonly IMapper _mapper;

        public QuestionService(IValidator<QuestionCreateDto> createDtoValidator, IValidator<QuestionUpdateDto> updateDtoValidator, IQuestionRepository questionRepository, IMapper mapper) : base(mapper, createDtoValidator, updateDtoValidator, questionRepository)
        {
            _createDtoValidator = createDtoValidator;
            _updateDtoValidator = updateDtoValidator;
            _questionRepository = questionRepository;
            _mapper = mapper;
        }

        public async Task<IResponse<List<QuestionListWithCategoryLectureUserDto>>> GetAllWithCategoryLectureUserAsync()
        {
            var data = await _questionRepository.GetAllWithCategoryLectureUserAsync();
            if (data == null)
            {
                return new Response<List<QuestionListWithCategoryLectureUserDto>>(ResponseType.NotFound, "Questions table is empty!");
            }
            var dto = _mapper.Map<List<QuestionListWithCategoryLectureUserDto>>(data);
            return new Response<List<QuestionListWithCategoryLectureUserDto>>(ResponseType.Success, dto);
        }

        public async Task<IResponse<QuestionListWithCategoryLectureUserDto>> GetByIdWithCategoryLectureUserAsync(int id)
        {
            var data = await _questionRepository.GetByIdWithCategoryLectureUserAsync(id);
            if (data == null)
            {
                return new Response<QuestionListWithCategoryLectureUserDto>(ResponseType.NotFound, $"Entity is not found with id {id}!");
            }
            var dto = _mapper.Map<QuestionListWithCategoryLectureUserDto>(data);
            return new Response<QuestionListWithCategoryLectureUserDto>(ResponseType.Success, dto);
        }
    }
}
