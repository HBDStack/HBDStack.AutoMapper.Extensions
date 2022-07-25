namespace HBD.AutoMapper.Lazy.Tests.Data;

public class Model
{
    public Model(string name) : this(Guid.NewGuid(), name)
    {
    }

    public Model(Guid id, string name)
    {
        Id = id;
        Name = name;
    }

    public Guid Id { get; }
    public string Name { get; }
}