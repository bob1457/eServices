using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eServices.AuthService.Command;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eServices.AuthService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost]
        [Route("signin")]
        public async Task<IActionResult> SignIn([FromBody] LoginCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }
    }
}