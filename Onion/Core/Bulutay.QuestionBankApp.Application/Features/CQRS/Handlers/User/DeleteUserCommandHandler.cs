using Bulutay.QuestionBankApp.Application.Common;
using Bulutay.QuestionBankApp.Application.Features.CQRS.Commands;
using Bulutay.QuestionBankApp.Application.Interfaces;
using MediatR;

namespace Bulutay.QuestionBankApp.Application.Features.CQRS.Handlers
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommandRequest, IResponse>
    {
        private readonly IUserService _userService;

        public DeleteUserCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IResponse> Handle(DeleteUserCommandRequest request, CancellationToken cancellationToken)
        {
            var response = await _userService.RemoveAsync(request.Id);
            return response;
        }
    }
}
