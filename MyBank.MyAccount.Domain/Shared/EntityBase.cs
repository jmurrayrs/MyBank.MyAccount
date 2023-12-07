namespace MyBank.MyAccount.Domain.Shared;

public abstract class EntityBase<TKey>
{
    public TKey Id { get; protected set; } = default!;

    protected EntityBase()
    {
        if (typeof(TKey).IsAssignableFrom(typeof(string)) && Id == null)
            SetId();
        else if (typeof(TKey).IsAssignableFrom(typeof(Guid)))
            Id = (TKey)Convert.ChangeType(Guid.NewGuid(), typeof(TKey));

    }

    public virtual bool Equals(EntityBase<TKey>? other)
    {
        if (Id == null || other == null)
            return false;

        return Id.Equals(other.Id);
    }

    private void SetId()
    {
        string newGuid = Guid.NewGuid().ToString();
        Id = (TKey)Convert.ChangeType(newGuid, typeof(TKey));
    }

    public override bool Equals(object? obj)
    {
        return base.Equals(obj);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public override string? ToString()
    {
        return base.ToString();
    }
}