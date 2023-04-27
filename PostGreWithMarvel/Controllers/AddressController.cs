using MarvelContract.RequestModel;
using MarvelContract.ResponseModel;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PostGreWithMarvel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AddressController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("/get-address")]
        public async Task<ActionResult<List<GetAddressResponse>>> GetAddress()
        {
            var response = await _mediator.Send(new GetUserRequest());
            return Ok(response);
        }
    }
}
