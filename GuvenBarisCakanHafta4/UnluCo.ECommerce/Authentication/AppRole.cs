using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace UnluCo.ECommerce.Authentication
{
    public class CreateRoles
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public CreateRoles(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }
        

    }
}

