using Microsoft.AspNet.Identity.EntityFramework;

internal class ApplicationRoleManager
{
    private RoleStore<IdentityRole> roleStore;

    public ApplicationRoleManager(RoleStore<IdentityRole> roleStore)
    {
        this.roleStore = roleStore;
    }

    internal bool RoleExists(string v)
    {
        throw new NotImplementedException();
    }
}