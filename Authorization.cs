using Microsoft.AspNetCore.Authorization;

namespace authority
{
    public static class Authorization
    {
        public const string UserPolicyName = "user";
        public static AuthorizationPolicy User { get; } = new AuthorizationPolicyBuilder()
            .RequireAuthenticatedUser()
            .Build();
        public const string AdminPolicyName = "admin";
        public static AuthorizationPolicy Admin { get; } = new AuthorizationPolicyBuilder()
            .RequireAuthenticatedUser()
            .RequireClaim("role", "admin")
            .Build();
        public const string PlayerPolicyName = "player";
        public static AuthorizationPolicy Player { get; } = new AuthorizationPolicyBuilder()
            .RequireAuthenticatedUser()
            .RequireClaim("role", "player", "admin", "subscriber")
            .Build();
        public const string SubscriberPolicyName = "subscriber";
        public static AuthorizationPolicy Subscriber { get; } = new AuthorizationPolicyBuilder()
            .RequireAuthenticatedUser()
            .RequireClaim("role", "subscriber", "admin")
            .Build();

        public static void AddPolicies(this AuthorizationOptions options)
        {
            options.AddPolicy(UserPolicyName, User);
            options.AddPolicy(AdminPolicyName, Admin);
            options.AddPolicy(PlayerPolicyName, Player);
            options.AddPolicy(SubscriberPolicyName, Subscriber);
        }
    }
}