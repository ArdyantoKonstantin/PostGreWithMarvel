using MarvelContract.ResponseModel;
using MarvelEntity.Entity;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MarvelContract.RequestModel;

namespace PostGreWithMarvel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("/get-user")]
        public async Task<ActionResult<List<GetUserResponse>>> GetUser()
        {
            var response = await _mediator.Send(new GetUserRequest());
            return Ok(response);
        }

        [HttpGet("/get-user/{name}")]
        public async Task<ActionResult<SearchUserResponse>> GetUserName(SearchUserRequest model)
        {
            var response = await _mediator.Send(model);
            return Ok(response);
        }

        [HttpPost("/register-user")]
        public async Task<ActionResult<RegisterUserResponse>> PostUser([FromBody] RegisterUserRequest model)
        {
            var response = await _mediator.Send(model);
            return Ok(response);
        }

        [HttpPut("update-user")]
        public async Task<ActionResult<UpdateUserResponse>> Put([FromBody] UpdateUserRequest model)
        {
            var response = await _mediator.Send(model);
            return Ok(response);
        }

        [HttpDelete("delete-user")]
        public async Task<ActionResult<DeleteUserResponse>> Delete([FromBody] DeleteUserRequest model)
        {
            var response = await _mediator.Send(model);
            return Ok(response);
        }

        [HttpGet("offset-pagination")]
        public async Task<ActionResult<OffsetPaginationResponse>> GetUserOffsetPagination([FromQuery] OffsetPaginationRequest model)
        {
            var response = await _mediator.Send(model);
            return Ok(response);
        }

        [HttpGet("cursor-pagination")]
        public async Task<ActionResult<CursorPaginationResponse>> GetUserCursorPagination([FromQuery] CursorPaginationRequest model)
        {
            var response = await _mediator.Send(model);
            return Ok(response);
        }
    }
}
