using eServices.AuthService.Command;
using eServices.AuthService.Data;
using eServices.AuthService.Models;
using eServices.AuthService.Models.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace eServices.AuthService.CommandHandler
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, AppUserViewModel>
    {
        private readonly ApplicationDbContext _appDbContext;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;

        private IMediator _mediator;
        public IConfiguration _config { get; }

        public RegisterCommandHandler(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager,/*IMapper mapper,, HttpClient httpClient*/
            ApplicationDbContext appDbContext, IMediator mediator, IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            //_mapper = mapper;
            _appDbContext = appDbContext;            
            _mediator = mediator;            
            _config = configuration;
        }
        public async Task<AppUserViewModel> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            //throw new NotImplementedException();

            var user = new ApplicationUser
            {
                UserName = request.UserName,
                Email = request.Email, // it is critical here, it comes from client via query string
                AvatarImgUrl = "Images/Avatars/default.png",
                //FirstName = request.FirstName,
                //LastName = request.LastName,
                JoinDate = DateTime.Now,
                LastUpdated = DateTime.Now,
                EmailConfirmed = true, // it will set FALSE later for user register requesting email confirmation
                UserRole = request.UserRole,
                OrganizationId = 0,
                IsDisabled = false,                
                // The following are not required here - will be populated in profile
                //Telephone1 = request.Telephone1,
                //Telephone2 = request.Telephone2,
                //AddressStreet = request.AddressStreet,
                //AddressCity = request.AddressCity,
                //AddressStateProv = request.AddressProvState,
                //AddressZipPostCode = request.AddressPostZipCode,
                //AddressCountry = request.AddressCountry
            };

            var userRegistered = new AppUserViewModel();

            try
            {
                var result = await _userManager.CreateAsync(user, request.Password);

                var role_result = await _userManager.AddToRoleAsync(user, request.UserRole);

                if (!result.Succeeded /*&& !role_resuls.Succeeded*/) return new AppUserViewModel() { Message = "Registration Failed! "};

                // TO DO: Send notification email or request email verification

                // Map the result to view model -- could be done by AutoMapper
                userRegistered.UserName = request.UserName;
                userRegistered.FirstName = request.FirstName;
                userRegistered.LastName = request.LastName;
                userRegistered.Email = request.Email;
                userRegistered.UserAvatarImgUrl = user.AvatarImgUrl;
                userRegistered.UserRole = request.UserRole;

                Log.Information("User {user} with {username} has registered successfully!", user.FirstName + user.LastName, user.UserName);
                return userRegistered;

            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error occured :(" + ex.Message);
                throw ex;
            }

        }
    }
}
