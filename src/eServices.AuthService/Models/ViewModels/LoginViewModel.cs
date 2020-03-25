using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eServices.AuthService.Models.ViewModels
{
    public class LoginViewModel
    {
        public string token { get; set; }
        public string errorMessage { get; set; }
        public ApplicationUser user { get; set; }
    }
}
