using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eServices.AuthService.Models.ViewModels
{
    public class AppUserViewModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string UserRole { get; set; }
        public string UserAvatarImgUrl { get; set; }
        public string Telephone1 { get; set; }
        public string Telephone2 { get; set; }
        public string SocialMediaContact1 { get; set; }
        public string SocialMediaContact2 { get; set; }
        public string AddressStreet { get; set; }
        public string AddressCity { get; set; }
        public string AddressProvState { get; set; }
        public string AddressPostZipCode { get; set; }
        public string AddressCountry { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public DateTime LastLogin { get; set; }
        public string Message { get; set; }
    }
}
