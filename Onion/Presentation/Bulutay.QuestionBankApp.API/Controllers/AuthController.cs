using AutoMapper;
using Bulutay.QuestionBankApp.API.Tools;
using Bulutay.QuestionBankApp.Application.Enums;
using Bulutay.QuestionBankApp.Application.Features.CQRS.Commands;
using Bulutay.QuestionBankApp.Application.Features.CQRS.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Bulutay.QuestionBankApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public AuthController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn(CheckUserQueryRequest request)
        {
            var response = await _mediator.Send(request);
            if(response.ResponseType == ResponseType.Success)
            {
                return Ok(JwtGenerator.GenerateToken(response.Data));
            }
            else if(response.ResponseType == ResponseType.NotFound)
            {
                return NotFound(response.Message);
            }
            return BadRequest(response.Message);
        }

        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp(CreateMemberUserCommandRequest request)
        {
            var response = await _mediator.Send(request);
            if (response.ResponseType == ResponseType.Success)
            {
                var signInRequest = _mapper.Map<CheckUserQueryRequest>(response.Data);
                return await SignIn(signInRequest);
            }
            return BadRequest(response.Message);
        }
    }
}
