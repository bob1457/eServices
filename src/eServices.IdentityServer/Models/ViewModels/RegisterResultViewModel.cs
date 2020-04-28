using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.Models.ViewModels
{
    public class RegisterResultViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }


        public RegisterResultViewModel(ApplicationUser user)
        {            
            FirstName = user.FirstName;
            LastName = user.LastName;
            Email = user.Email;
        }

        //public RegisterResultViewModel()
        //{

        //}
    }
}
