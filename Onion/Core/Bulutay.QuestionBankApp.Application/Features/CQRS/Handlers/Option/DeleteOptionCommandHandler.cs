using Bulutay.QuestionBankApp.Application.Common;
using Bulutay.QuestionBankApp.Application.Features.CQRS.Commands;
using Bulutay.QuestionBankApp.Application.Interfaces;
using MediatR;

namespace Bulutay.QuestionBankApp.Application.Features.CQRS.Handlers
{
    public class DeleteOptionCommandHandler : IRequestHandler<DeleteOptionCommandRequest, IResponse>
    {
        private readonly IOptionService _optionService;

        public DeleteOptionCommandHandler(IOptionService optionService)
        {
            _optionService = optionService;
        }

        public Task<IResponse> Handle(DeleteOptionCommandRequest request, CancellationToken cancellationToken)
        {
            var response = _optionService.RemoveAsync(request.Id);
            return response;
        }
    }
}
