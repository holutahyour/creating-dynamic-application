namespace Application.Core.Domain;

public abstract class BaseEntity
{
    public string id { get; set; }  = Guid.NewGuid().ToString();
    public string Code { get; set; } = Guid.NewGuid().ToString();
}
