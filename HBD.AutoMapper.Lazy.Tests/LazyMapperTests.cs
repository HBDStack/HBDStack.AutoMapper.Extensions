using AutoMapper;
using FluentAssertions;
using HBD.AutoMapper.Lazy.Tests.Data;
using Microsoft.Extensions.DependencyInjection;

namespace HBD.AutoMapper.Lazy.Tests;

public class LazyMapperTests : IClassFixture<LazyMapFixture>
{
    private readonly LazyMapFixture _fixture;

    public LazyMapperTests(LazyMapFixture fixture) => _fixture = fixture;

    [Fact]
    public void LazyMap_Test()
    {
        var mapper = _fixture.ServiceProvider.GetRequiredService<IMapper>();
        var m = new Model("Steven");
        var v = mapper.LazyMap<View>(m);

        v.Value.Should().NotBeNull();
        v.Value.Should().NotBe(m);
        v.Value!.Id.Should().Be(m.Id);
        v.Value!.Name.Should().Be(m.Name);
    }

    [Fact]
    public void LazyMap_TheSameType_Test()
    {
        var mapper = _fixture.ServiceProvider.GetRequiredService<IMapper>();
        var m = new Model("Steven");
        var v = mapper.LazyMap<Model>(m);

        v.Value.Should().NotBeNull();
        v.Value.Should().Be(m);
    }

    [Fact]
    public void LazyMap_NullValue_Test()
    {
        var mapper = _fixture.ServiceProvider.GetRequiredService<IMapper>();
        var v = mapper.LazyMap<Model>(null!);
        v.Value.Should().BeNull();
    }
}