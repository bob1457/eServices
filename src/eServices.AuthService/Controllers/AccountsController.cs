using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eServices.AuthService.Command;
using eServices.AuthService.Data;
using eServices.AuthService.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace eServices.AuthService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IMediator _mediator; // Only this one is required

        private readonly ApplicationDbContext _appDbContext;

        // The following are not required
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;

        public AccountsController(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager,
            /*IMapper mapper,IMessagePublisher messagePublisher,*/ 
            ApplicationDbContext appDbContext, IMediator mediator)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            //_mapper = mapper;
            //_messagePublisher = messagePublisher;
            _appDbContext = appDbContext;
            _mediator = mediator;
        }


        [HttpPost]
        [Route("addrole")]
        public async Task<IActionResult> AddRole([FromBody]AddUserRoleCommand command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterCommand command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _mediator.Send(command);

            return Ok(result);
        }
    }
}