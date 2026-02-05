namespace Orderly.Domain.Common;

public abstract class AuditableEntity : Entity
{
    public DateTime CreatedAt { get; protected set; }
    public string? CreatedBy { get; protected set; }

    public DateTime? LastModifiedAt { get; protected set; }
    public string? LastModifiedBy { get; protected set; }

    protected AuditableEntity()
    {
        CreatedAt = DateTime.UtcNow;
    }

    public void SetCreated(string user)
    {
        CreatedBy = user;
    }

    public void SetModified(string user)
    {
        LastModifiedAt = DateTime.UtcNow;
        LastModifiedBy = user;
    }
}

