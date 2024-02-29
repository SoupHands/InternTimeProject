using Microsoft.AspNetCore.Identity;
using System;


namespace InternTimeProject.Models
{
    public class AppRoleManager : AppRoleManager<IdentityRole>

    {
        public AppRoleManager(IdRoleStore<IdentityRole, string> roleStore)
            : base(roleStore)
        {

        }
        public static AppRoleManager Create(IdentityFactoryOptions<AppRoleManager> options, IOwinContext context)
        {
            var roleManager = new AppRoleManager(new RoleStore<IdentityRole>(context.Get<ApplicationDbContext>()));
            return roleManager;
        }
    }
}
