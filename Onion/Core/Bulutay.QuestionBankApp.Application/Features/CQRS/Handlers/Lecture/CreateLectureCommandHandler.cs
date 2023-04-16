using AutoMapper;
using Bulutay.QuestionBankApp.Application.Common;
using Bulutay.QuestionBankApp.Application.Dtos;
using Bulutay.QuestionBankApp.Application.Features.CQRS.Commands;
using Bulutay.QuestionBankApp.Application.Interfaces;
using MediatR;

namespace Bulutay.QuestionBankApp.Application.Features.CQRS.Handlers
{
    public class CreateLectureCommandHandler : IRequestHandler<CreateLectureCommandRequest, IResponse<LectureCreateDto>>
    {
        private readonly ILectureService _lectureService;
        private readonly IMapper _mapper;

        public CreateLectureCommandHandler(ILectureService lectureService, IMapper mapper)
        {
            _lectureService = lectureService;
            _mapper = mapper;
        }

        public Task<IResponse<LectureCreateDto>> Handle(CreateLectureCommandRequest request, CancellationToken cancellationToken)
        {
            var dto = _mapper.Map<LectureCreateDto>(request);
            var response = _lectureService.CreateAsync(dto);
            return response;
        }
    }
}
