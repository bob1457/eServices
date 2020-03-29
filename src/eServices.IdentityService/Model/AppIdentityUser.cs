using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eServices.IdentityService.Model
{
    public class AppIdentityUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserRole { get; set; }
        public int OrganizationId { get; set; }
        public bool IsDisabled { get; set; }
        public string AvatarImgUrl { get; set; }
        public string Telephone1 { get; set; }
        public string Telephone2 { get; set; }
        public string SocialMediaContact1 { get; set; }
        public string SocialMediaContact2 { get; set; }
        public string AddressStreet { get; set; }
        public string AddressCity { get; set; }
        public string AddressStateProv { get; set; }
        public string AddressZipPostCode { get; set; }
        public string AddressCountry { get; set; }
        public DateTime JoinDate { get; set; }
        public DateTime LastLogOn { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
