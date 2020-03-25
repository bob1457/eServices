using eServices.AuthService.Models.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eServices.AuthService.Command
{
    public class RegisterCommand : IRequest<AppUserViewModel>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string UserRole { get; set; }

        //public string Telephone1 { get; set; }
        //public string Telephone2 { get; set; }
        //public string SocialMediaContact1 { get; set; }
        //public string SocialMediaContact2 { get; set; }
        //public string AddressStreet { get; set; }
        //public string AddressCity { get; set; }
        //public string AddressProvState { get; set; }
        //public string AddressPostZipCode { get; set; }
        //public string AddressCountry { get; set; }
    }
}
