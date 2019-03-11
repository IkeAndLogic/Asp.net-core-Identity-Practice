using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class DbInitializer
    {
        private static readonly string[] _roleArray = { "Admin", "Terminal Manager", "Dispatcher", "Driver", "Mechanic", "Recruiter", "Mechanic Manger" };

        public static async Task InitializeAync (TransportDbContext context, IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<Role>>();


            foreach (string index in _roleArray)
            {
                if ((await roleManager.FindByNameAsync(index)) == null)
                {
                    await roleManager.CreateAsync(new Role { Name = index });
                }
            }

        }
    }
}
