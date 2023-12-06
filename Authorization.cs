using Microsoft.AspNetCore.Authorization;

namespace authority
{
    public static class Authorization
    {
        public static AuthorizationPolicy User { get; } = new AuthorizationPolicyBuilder()
            .RequireAuthenticatedUser()
            .Build();
        public static AuthorizationPolicy Admin { get; } = new AuthorizationPolicyBuilder()
            .RequireAuthenticatedUser()
            .RequireClaim("role", "admin")
            .Build();
        public static AuthorizationPolicy Player { get; } = new AuthorizationPolicyBuilder()
            .RequireAuthenticatedUser()
            .RequireClaim("role", "player", "admin", "subscriber")
            .Build();
        public static AuthorizationPolicy Subscriber { get; } = new AuthorizationPolicyBuilder()
            .RequireAuthenticatedUser()
            .RequireClaim("role", "subscriber", "admin")
            .Build();
    }
}