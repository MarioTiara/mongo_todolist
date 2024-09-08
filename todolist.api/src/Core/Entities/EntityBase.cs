namespace Core.Entities;

public abstract class EntityBase
{
    public string Id { get; private  set; }
    public DateTime CreatedDate { get;  private set; }
    public DateTime UpdatedDate { get;  private set; }
    public bool IsDeleted { get;  private set; } 

    protected EntityBase()
    {
        Id = Guid.NewGuid().ToString();
        CreatedDate = DateTime.UtcNow;;
        UpdatedDate =DateTime.UtcNow;
        IsDeleted = false;
    }

    public void Delete()
    {
        IsDeleted = true;
        UpdatedDate = DateTime.UtcNow;
    }

    public void RefreshUpdateDate()
    => UpdatedDate = DateTime.UtcNow;

    
}
