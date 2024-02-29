using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System;

private void CreateRole()
{
    var roleManager = new ApplicationRoleManager(new RoleStore<IdentityRole>(new ApplicationDbContext()));

    // Create roles if they don't exist
    if (!roleManager.RoleExists("Supervisor"))
    {
        var role = new IdentityRole("Supervisor");
        roleManager.Create(role);
    }

    if (!roleManager.RoleExists("Intern"))
    {
        var role = new IdentityRole("Intern");
        roleManager.Create(role);
    }
}
// Inside ConfigureAuth method
public void ConfigureAuth(IAppBuilder app)
{
    app.CreatePerOwinContext(ApplicationDbContext.Create);
    app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
    app.CreatePerOwinContext<ApplicationSignInManager>(ApplicationSignInManager.Create);

    // Enable the application to use a cookie to store information for the signed-in user
    app.UseCookieAuthentication(new CookieAuthenticationOptions
    {
        AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
        LoginPath = new PathString("/Account/Login"),
        Provider = new CookieAuthenticationProvider
        {
            OnValidateIdentity = SecurityStampValidator.OnValidateIdentity<ApplicationUserManager, ApplicationUser>(
                validateInterval: TimeSpan.FromMinutes(30),
                regenerateIdentity: (manager, user) => user.GenerateUserIdentityAsync(manager))
        }
    });

}

internal class ApplicationUser
{
}

internal class ApplicationSignInManager
{
}

internal class ApplicationUserManager
{
}