using System.Security.Claims;
using JWT.Algorithms;
using JWT.Extensions.AspNetCore;
using Microsoft.AspNetCore.Authentication;

namespace authority
{
    public static class JWTExtension
    {
        private static string Authority { get; set; } = "dnd-authority";
        private static string CurrentApp { get; set; } = "dnd-authority";

        private static readonly List<(string key, Func<JWTUser, string> get, Action<JWTUser, string> set)> _keys =
        [
            ("iss", (user) => user.Issuer, (user, value) => user.Issuer = value),
            ("sub", (user) => user.Guid.ToString(), (user, value) => user.Guid = Guid.Parse(value)),
            ("aud", (user) => user.Audience.Aggregate("", (current,next) => current == "" ? next : $"{current},{next}"),
                (user, value) => user.Audience = value.Split(",")),
            ("exp", (user) => user.Expiration.ToEpoch().ToString(),
                (user, value) => user.Expiration = Convert.ToInt64(value).ToDateTime()),
            ("iat", (user) => user.IssuedAt.ToEpoch().ToString(),
                (user, value) => user.IssuedAt = Convert.ToInt64(value).ToDateTime()),
            ("name", (user) => user.Name, (user, value) => user.Name = value),
            ("email", (user) => user.Email, (user, value) => user.Email = value),
            ("role", (user) => user.Role ?? "", (user, value) => user.Role = value),
            ("llat", (user) => user.LastLogIn?.ToEpoch().ToString() ?? "",
                (user, value) => user.LastLogIn = Convert.ToInt64(value).ToDateTime()),
            ("upat", (user) => user.UpdatedAt.ToEpoch().ToString(),
                (user, value) => user.UpdatedAt = Convert.ToInt64(value).ToDateTime()),
        ];
        public static long ToEpoch(this DateTime dateTime) =>
            Convert.ToInt64((dateTime.ToUniversalTime() - new DateTime(1970, 1, 1)).TotalMilliseconds);

        public static DateTime ToDateTime(this long epoch) =>
            DateTimeOffset.FromUnixTimeMilliseconds(epoch).DateTime.ToUniversalTime();

        public static JWTUser ToJwtUser(this User user, string issuer, DateTime expiration, params string[] audiance) =>
            new(user)
            {
                Issuer = issuer,
                Expiration = expiration,
                Audience = audiance
            };

        public static IEnumerable<KeyValuePair<string, object>> GetClaims(this JWTUser user) =>
            _keys.Select(key => KeyValuePair.Create<string, object>(key.key, key.get(user)))
                .Where((pair) => pair.Value.ToString() != "");

        public static JWTUser GetUser(this ClaimsPrincipal principal) =>
            GetUser(principal.Claims
                .ToDictionary(claim => claim.Type, claim => claim.Value));

        public static JWTUser GetUser(Dictionary<string, string> dic)
        {
            var user = new JWTUser();
            dic.ToList().ForEach(claim =>
            {
                if (_keys.FirstOrDefault(key => key.key == claim.Key) is { } found)
                    found.set(user, claim.Value);
            });
            return user;
        }

        public static void VerifyJWTToken(this JWTUser user)
        {
            if (user.Issuer != Authority)
                throw new Exception("Unknown issuer authority");
            if (!user.Audience.Contains(CurrentApp))
                throw new Exception("App is not in scope of token");
            if (user.Expiration <= DateTime.UtcNow)
                throw new Exception("Token is expired");
            if (user.IssuedAt >= DateTime.UtcNow)
                throw new Exception("Token is tampered with");
        }

        public static void AddJWTAuthentication(this WebApplicationBuilder builder)
        {
            Authority = builder.Configuration.GetValue<string>("Authority") ?? Authority;
            CurrentApp = builder.Configuration.GetValue<string>("App") ?? CurrentApp;

            builder.Services.AddSingleton<IPublicRSAProvider>(
                    new PublicRSAProvider(builder.Configuration.GetValue<string>("Public_Key") ?? ".public.pem"));

            builder.Services.AddSingleton<IAlgorithmFactory>(sp =>
                new RSAlgorithmFactory(sp.GetRequiredService<IPublicRSAProvider>().Key));

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtAuthenticationDefaults.AuthenticationScheme;
            }).AddJwt(options =>
            {
                options.OnSuccessfulTicket = (logger, ticket) =>
                {
                    try
                    {
                        ticket.Principal.GetUser().VerifyJWTToken();
                    }
                    catch (Exception ex)
                    {
                        return AuthenticateResult.Fail(ex);
                    }
                    return AuthenticateResult.Success(ticket);
                };
            });
        }
    }
}