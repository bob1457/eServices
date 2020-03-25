using eServices.AuthService.Command;
using eServices.AuthService.Data;
using eServices.AuthService.Models;
using eServices.AuthService.Models.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace eServices.AuthService.CommandHandler
{
    public class AddUserRoleCommandHandler : IRequestHandler<AddUserRoleCommand, RoleViewModel>
    {
        private readonly ApplicationDbContext _appDbContext;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly ILogger<AddUserRoleCommandHandler> _logger;

        public AddUserRoleCommandHandler(ApplicationDbContext appDbContext, RoleManager<ApplicationRole> roleManager, ILogger<AddUserRoleCommandHandler> logger)
        {
            _appDbContext = appDbContext;
            _roleManager = roleManager;
            _logger = logger;
        }

        public async Task<RoleViewModel> Handle(AddUserRoleCommand request, CancellationToken cancellationToken)
        {
            //throw new NotImplementedException();

            ApplicationRole role = new ApplicationRole();
            role.Name = request.Name;
            role.Description = request.Description;

            var roleAdded = new RoleViewModel();

            try
            {
                var result = await _roleManager.CreateAsync(role);  
                
                await _appDbContext.SaveChangesAsync();

                roleAdded.Name = request.Name;
                roleAdded.Description = request.Description;
                
                _logger.LogInformation("Role:" + request.Name + " has been added");

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occured :(" + ex.Message);
                throw ex;
            }

            return roleAdded;
        }
    }
}
