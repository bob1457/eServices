using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eServices.IdentityService.Model.ViewModel
{
    public class AppUserViewModel
    {
        
        public AppUserViewModel(AppIdentityUser user)
        {
            Email = user.Email;           
            FirstName = user.FirstName;
            LastName = user.LastName;
            UserName = user.UserName;
            UserRole = user.UserRole;
            UserAvatarImgUrl = user.AvatarImgUrl;
            Telephone1 = user.Telephone1;
            Telephone2 = user.Telephone2;
            SocialMediaContact1 = user.AvatarImgUrl;
            SocialMediaContact2 = user.SocialMediaContact2;
            AddressStreet = user.AddressStreet;
            AddressCity = user.AddressCity;
            AddressProvState = user.AddressStateProv;
            AddressPostZipCode = user.AddressZipPostCode;
            AddressCountry = user.AddressCountry;
            Created = user.JoinDate;
            Updated = user.LastUpdated;
            LastLogin = user.LastLogOn;            
        }

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
