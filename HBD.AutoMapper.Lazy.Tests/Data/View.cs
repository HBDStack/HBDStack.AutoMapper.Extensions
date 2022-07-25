using AutoMapper;

namespace HBD.AutoMapper.Lazy.Tests.Data;

[AutoMap(typeof(Model))]
public record View
{
    public Guid Id { get; set; } = default!;
    public string Name { get; set; } = default!;
}