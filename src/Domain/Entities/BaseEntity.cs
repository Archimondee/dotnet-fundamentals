namespace DotnetCA.Domain.Entities;

public abstract class BaseEntity
{
    public Guid Id { get; protected set; }

    public DateTime? CreatedAt { get; protected set; }

    public DateTime? UpdatedAt { get; protected set; }

    public DateTime? DeletedAt { get; protected set; }

    protected BaseEntity()
    {
        Id = Guid.NewGuid();
        CreatedAt = DateTime.UtcNow;
    }

    private void Touch()
    {
        DeletedAt = DateTime.UtcNow;
    }

    public void SoftDelete()
    {
        DeletedAt = DateTime.UtcNow;
        Touch();
    }
}