using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eServices.AuthService.Models
{
    public class ApplicationRole : IdentityRole
    {
        public string Description { get; set; }
    }
}
