using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eServices.IdentityService.Command
{
    public class AddUserRoleCommand
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
