using AutoMapper;
using Bulutay.QuestionBankApp.Application.Common;
using Bulutay.QuestionBankApp.Application.Dtos;
using Bulutay.QuestionBankApp.Application.Enums;
using Bulutay.QuestionBankApp.Application.Extensions;
using Bulutay.QuestionBankApp.Application.Interfaces;
using Bulutay.QuestionBankApp.Domain.Entities;
using FluentValidation;
using System.Linq.Expressions;

namespace Bulutay.QuestionBankApp.Application.Services
{
    public class Service<CreateDto, UpdateDto, ListDto, T> : IService<CreateDto, UpdateDto, ListDto, T>
        where CreateDto : class, IDto, new()
        where UpdateDto : class, IUpdateDto, new()
        where ListDto : class, IDto, new()
        where T : BaseEntity
    {
        private readonly IMapper _mapper;
        private readonly IValidator<CreateDto> _createDtoValidator;
        private readonly IValidator<UpdateDto> _updateDtoValidator;
        private readonly IRepository<T> _repository;

        public Service(IMapper mapper, IValidator<CreateDto> createDtoValidator, IValidator<UpdateDto> updateDtoValidator, IRepository<T> repository)
        {
            _mapper = mapper;
            _createDtoValidator = createDtoValidator;
            _updateDtoValidator = updateDtoValidator;
            _repository = repository;
        }

        public async Task<IResponse<CreateDto>> CreateAsync(CreateDto dto)
        {
            var validationResult = _createDtoValidator.Validate(dto);
            if (validationResult.IsValid)
            {
                var entity = _mapper.Map<T>(dto);
                await _repository.CreateAsync(entity);
                await _repository.CommitAsync();
                return new Response<CreateDto>(ResponseType.Success, "Entity is created!", dto);
            }
            return new Response<CreateDto>("Validation errors occured!", dto, validationResult.ConvertToCustomValidationError());
        }

        public async Task<IResponse<List<ListDto>>> GetAllAsync()
        {
            var data = await _repository.GetAllAsync();
            if(data == null || data != null && data.Count == 0)
            {
                return new Response<List<ListDto>>(ResponseType.NotFound, "Table is empty!");
            }
            var dto = _mapper.Map<List<ListDto>>(data);
            return new Response<List<ListDto>>(ResponseType.Success, dto);
        }

        public async Task<IResponse<List<ListDto>>> GetAllAsync(Expression<Func<T, bool>> filter)
        {
            var data = await _repository.GetAllAsync(filter);
            if (data == null || data != null && data.Count == 0)
            {
                return new Response<List<ListDto>>(ResponseType.NotFound, "Table is empty!");
            }
            var dto = _mapper.Map<List<ListDto>>(data);
            return new Response<List<ListDto>>(ResponseType.Success, dto);
        }

        public async Task<IResponse<ListDto>> GetByFilterAsync(Expression<Func<T, bool>> filter)
        {
            var entity = await _repository.GetByFilterAsync(filter);
            if (entity == null)
            {
                return new Response<ListDto>(ResponseType.NotFound, $"Entity is not found!");
            }
            var dto = _mapper.Map<ListDto>(entity);
            return new Response<ListDto>(ResponseType.Success, dto);
        }

        public async Task<IResponse<ListDto>> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
            {
                return new Response<ListDto>(ResponseType.NotFound, $"Entity is not found with id {id}!");
            }
            var dto = _mapper.Map<ListDto>(entity);
            return new Response<ListDto>(ResponseType.Success, dto);
        }

        public async Task<IResponse> RemoveAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
            {
                return new Response(ResponseType.NotFound, $"Entity is not found with id {id}!");
            }
            _repository.Remove(entity);
            await _repository.CommitAsync();
            return new Response(ResponseType.Success, "Entity is removed!");
        }

        public async Task<IResponse<UpdateDto>> UpdateAsync(UpdateDto dto)
        {
            var result = _updateDtoValidator.Validate(dto);
            if (result.IsValid)
            {
                var unchangedEntity = await _repository.GetByIdAsync(dto.Id, true);
                if (unchangedEntity == null)
                {
                    return new Response<UpdateDto>(ResponseType.NotFound, $"Entity is not found with id {dto.Id}!", dto);
                }
                var entity = _mapper.Map<T>(dto);
                _repository.Update(entity, unchangedEntity);
                await _repository.CommitAsync();
                return new Response<UpdateDto>(ResponseType.Success, "Entity is updated!", dto);
            }
            return new Response<UpdateDto>("Validation errors occured!", dto, result.ConvertToCustomValidationError());
        }
    }
}
