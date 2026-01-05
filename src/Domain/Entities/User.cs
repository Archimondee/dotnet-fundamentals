namespace DotnetCA.Domain.Entities;

public sealed class User : BaseEntity
{
    public string Username { get; private set; }

    public string Password { get; private set; }

    public string Name { get; private set; } = "";

    public Guid? RoleId { get; set; }

    public Role Role { get; private set; } = default!;

    private User()
    {
    }

    public User(string username, string password, Guid roleId, string name)
    {
        Id = Guid.NewGuid();
        Username = username;
        Password = password;
        RoleId = roleId;
        Name = name;
        CreatedAt = DateTime.UtcNow;
    }

    public void UpdatePassword(string password)
    {
        Password = password;
        UpdatedAt = DateTime.UtcNow;
    }
}