using Microsoft.AspNetCore.Authorization;

namespace DrDoc.WebFramework.Attributes;

public class RolesAttribute : AuthorizeAttribute
{
    public RolesAttribute(params string[] roles)
    {
        Roles = string.Join(",", roles);
    }
}