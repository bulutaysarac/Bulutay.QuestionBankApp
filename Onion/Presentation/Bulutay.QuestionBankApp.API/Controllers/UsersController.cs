using Bulutay.QuestionBankApp.Application.Enums;
using Bulutay.QuestionBankApp.Application.Features.CQRS.Commands;
using Bulutay.QuestionBankApp.Application.Features.CQRS.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bulutay.QuestionBankApp.API.Controllers
{
    //[Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _mediator.Send(new GetUsersQueryRequest());
            if(response.ResponseType == ResponseType.Success)
            {
                return Ok(response.Data);
            }
            else if (response.ResponseType == ResponseType.NotFound)
            {
                return NotFound(response.Message);
            }
            return BadRequest(response.Message);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var response = await _mediator.Send(new GetUserQueryRequest(id));
            if (response.ResponseType == ResponseType.Success)
            {
                return Ok(response.Data);
            }
            else if (response.ResponseType == ResponseType.NotFound)
            {
                return NotFound(response.Message);
            }
            return BadRequest(response.Message);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateUserCommandRequest request)
        {
            var response = await _mediator.Send(request);
            if (response.ResponseType == ResponseType.Success)
            {
                return Ok(response.Message);
            }
            return BadRequest(response.Message);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateUserCommandRequest request)
        {
            var response = await _mediator.Send(request);
            if (response.ResponseType == ResponseType.Success)
            {
                return Ok(response.Data);
            }
            else if (response.ResponseType == ResponseType.NotFound)
            {
                return NotFound(response.Message);
            }
            return BadRequest(response.Message);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Update(int id)
        {
            var response = await _mediator.Send(new DeleteUserCommandRequest(id));
            if (response.ResponseType == ResponseType.Success)
            {
                return Ok(response.Message);
            }
            else if (response.ResponseType == ResponseType.NotFound)
            {
                return NotFound(response.Message);
            }
            return BadRequest(response.Message);
        }
    }
}
