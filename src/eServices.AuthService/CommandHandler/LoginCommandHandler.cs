//using AutoMapper.Configuration;
using Microsoft.Extensions.Configuration;
using eServices.AuthService.Command;
using eServices.AuthService.Models;
using eServices.AuthService.Models.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace eServices.AuthService.CommandHandler
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginViewModel>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly Microsoft.Extensions.Configuration.IConfiguration _configuration;
        private readonly ILogger<LoginCommandHandler> _logger;

        //public IConfiguration _configuration { get; }

        public LoginCommandHandler(UserManager<ApplicationUser> userManager, 
            SignInManager<ApplicationUser> signInManager, 
            IConfiguration configuration,
            ILogger<LoginCommandHandler> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
            _logger = logger;
        }

        public async Task<LoginViewModel> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            //throw new NotImplementedException();

            ApplicationUser user = await _userManager.FindByNameAsync(request.UserName);

            var userToVerify = await _userManager.CheckPasswordAsync(user, request.Password);

            if (!userToVerify)
            {
                Log.Information("User " + request.UserName + " failed to login.");
                return new LoginViewModel() { errorMessage = "Login failed!" };

                //return new LoginCommandResult();
                //return null;
            }

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, request.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(ClaimTypes.Role, user.UserRole)
                // More claims ...
            };

            

            var token = new JwtSecurityToken
                          (
                              issuer: _configuration["Token:Issuer"],
                              audience: _configuration["Token:Audience"],
                              claims: claims,
                              expires: DateTime.UtcNow.AddDays(60),
                              notBefore: DateTime.UtcNow,
                              signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Token:Key"])),
                                      SecurityAlgorithms.HmacSha256)
                          );

            var encodedToken = new JwtSecurityTokenHandler().WriteToken(token);

            _logger.LogInformation("User " + request.UserName + " logged in.");

            // Update lastlogin date
            //
            var loggedinUser = await _userManager.FindByNameAsync(request.UserName);
            loggedinUser.LastLogOn = DateTime.Now;
            await _userManager.UpdateAsync(loggedinUser);

            return new LoginViewModel() { token = encodedToken, user = user };
        }
    }
}
