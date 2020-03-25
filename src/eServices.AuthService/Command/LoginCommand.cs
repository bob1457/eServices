using eServices.AuthService.Models.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eServices.AuthService.Command
{
    public class LoginCommand : IRequest<LoginViewModel>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }

    }
}
