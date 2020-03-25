using eServices.AuthService.Models.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eServices.AuthService.Command
{
    public class AddUserRoleCommand : IRequest<RoleViewModel>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
