using AutoMapper;
using Bulutay.QuestionBankApp.Application.Common;
using Bulutay.QuestionBankApp.Application.Dtos;
using Bulutay.QuestionBankApp.Application.Enums;
using Bulutay.QuestionBankApp.Application.Interfaces;
using Bulutay.QuestionBankApp.Domain.Entities;
using FluentValidation;

namespace Bulutay.QuestionBankApp.Application.Services
{
    public class LectureService : Service<LectureCreateDto, LectureUpdateDto, LectureListDto, Lecture>, ILectureService
    {
        private readonly IMapper _mapper;
        private readonly ILectureRepository _lectureRepository;
        public LectureService(IMapper mapper, IValidator<LectureCreateDto> createDtoValidator, IValidator<LectureUpdateDto> updateDtoValidator, ILectureRepository repository) : base(mapper, createDtoValidator, updateDtoValidator, repository)
        {
            _mapper = mapper;
            _lectureRepository = repository;
        }

        public async Task<IResponse<List<LectureListDto>>> GetAllByDepartmentIdAsync(int departmentId)
        {
            var data = await _lectureRepository.GetAllAsync(x => x.Department.Id == departmentId);
            if (data == null || data != null && data.Count == 0)
            {
                return new Response<List<LectureListDto>>(ResponseType.NotFound, $"No lecture is found with department id {departmentId}!");
            }
            var dto = _mapper.Map<List<LectureListDto>>(data);
            return new Response<List<LectureListDto>>(ResponseType.Success, dto);
        }

        public async Task<IResponse<List<LectureListWithDepartmentDto>>> GetAllWithDepartmentAsync()
        {
            var data = await _lectureRepository.GetAllWithDepartmentAsync();
            if(data == null || data != null && data.Count == 0)
            {
                return new Response<List<LectureListWithDepartmentDto>>(ResponseType.NotFound, "Lectures table is empty!");
            }
            var dto = _mapper.Map<List<LectureListWithDepartmentDto>>(data);
            return new Response<List<LectureListWithDepartmentDto>>(ResponseType.Success, dto);
        }

        public async Task<IResponse<LectureListWithDepartmentDto>> GetByIdWithDepartmentAsync(int id)
        {
            var data = await _lectureRepository.GetByIdWithDepartmentAsync(id);
            if(data == null)
            {
                return new Response<LectureListWithDepartmentDto>(ResponseType.NotFound, $"Entity is not found with id {id}!");
            }
            var dto = _mapper.Map<LectureListWithDepartmentDto>(data);
            return new Response<LectureListWithDepartmentDto>(ResponseType.Success, dto);
        }
    }
}
