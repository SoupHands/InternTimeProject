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
