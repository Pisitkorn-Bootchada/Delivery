using System.Security.Claims;

public static class IdentityExtentions
{

    public static string GetRole(this ClaimsPrincipal user)
    {
        return user.FindFirst(ClaimTypes.Role)?.Value;
    }

    public static string GetName(this ClaimsPrincipal user)
    {
        return user.FindFirst(ClaimTypes.Name)?.Value;
    }
    public static string GetToken(this ClaimsPrincipal user)
    {
        return user.FindFirst("Token")?.Value;
    }
        public static string GetSurname(this ClaimsPrincipal user)
    {
        return user.FindFirst("Surname")?.Value;
    }

}