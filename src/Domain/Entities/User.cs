namespace DotnetCA.Domain.Entities;

public sealed class User : BaseEntity
{
    public string Username { get; private set; }

    public string Password { get; private set; }

    public Guid RoleId { get; set; }

    public Role Role { get; private set; }

    private User()
    {
    }

    public User(string username, string password, Guid roleId)
    {
        Id = Guid.NewGuid();
        Username = username;
        Password = password;
        RoleId = roleId;
        CreatedAt = DateTime.UtcNow;
    }

    public void UpdatePassword(string password)
    {
        Password = password;
        UpdatedAt = DateTime.UtcNow;
    }
}