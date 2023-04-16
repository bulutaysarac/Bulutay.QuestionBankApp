using AutoMapper;
using Bulutay.QuestionBankApp.Application.Common;
using Bulutay.QuestionBankApp.Application.Dtos;
using Bulutay.QuestionBankApp.Application.Features.CQRS.Commands;
using Bulutay.QuestionBankApp.Application.Interfaces;
using MediatR;

namespace Bulutay.QuestionBankApp.Application.Features.CQRS.Handlers
{
    public class UpdateLectureCommandHandler : IRequestHandler<UpdateLectureCommandRequest, IResponse<LectureUpdateDto>>
    {
        private readonly ILectureService _lectureService;
        private readonly IMapper _mapper;

        public UpdateLectureCommandHandler(ILectureService lectureService, IMapper mapper)
        {
            _lectureService = lectureService;
            _mapper = mapper;
        }

        public Task<IResponse<LectureUpdateDto>> Handle(UpdateLectureCommandRequest request, CancellationToken cancellationToken)
        {
            var dto = _mapper.Map<LectureUpdateDto>(request);
            var response = _lectureService.UpdateAsync(dto);
            return response;
        }
    }
}
