using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eServices.IdentityService.Command
{
    public class RegisterCommand
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string UserRole { get; set; }
    }
}
