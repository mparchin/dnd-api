namespace authority
{
    public class User
    {
        public Guid Guid { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = "";
        public string Email { get; set; } = "";
        public string? Role { get; set; }
        public DateTime? LastLogIn { get; set; }
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }

    public class DbUser : User
    {
        public int Id { get; set; }
        public string Salt { get; set; } = "";
        public string Password { get; set; } = "";
    }

    public class JWTUser : User
    {
        public string Issuer { get; set; } = "";
        public string[] Audience { get; set; } = [];
        public DateTime Expiration { get; set; }
        public DateTime IssuedAt { get; set; } = DateTime.UtcNow;

        public JWTUser() : base() { }
        public JWTUser(User user) : base()
        {
            Guid = user.Guid;
            Name = user.Name;
            Email = user.Email;
            Role = user.Role;
            LastLogIn = user.LastLogIn;
            UpdatedAt = user.UpdatedAt;
        }
    }
}