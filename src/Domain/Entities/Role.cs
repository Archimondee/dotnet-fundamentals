namespace DotnetCA.Domain.Entities;

public sealed class Role : BaseEntity
{
    public string RoleName { get; private set; }

    private Role()
    {
    }

    public Role(string roleName)
    {
        Id = Guid.NewGuid();
        RoleName = roleName;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
    }
}