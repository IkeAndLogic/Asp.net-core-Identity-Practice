using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.ViewModels
{
    public class RoleViewModel
    {
        public List<IdentityRole> Roles { get; set; }

        public RoleViewModel (List<IdentityRole> roles)
        {
            Roles = roles;
        }
}
}
