using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eServices.IdentityService.Model.ViewModel
{
    public class RoleViewModel
    {
        //private AppIdentityRole _role;
        public RoleViewModel(AppIdentityRole role)
        {
            Name = role.Name;
            Description = role.Description;
        }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
