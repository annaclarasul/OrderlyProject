namespace Orderly.Domain.Common;

public abstract class Entity
{
    public Guid Id { get; protected set; }

    protected Entity()
    {
        Id = Guid.NewGuid();
    }

    public override bool Equals(object? obj)
    {
        if (obj is not Entity other)
            return false;

        return Id == other.Id && GetType() == other.GetType();
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Id, GetType());
    }
}

