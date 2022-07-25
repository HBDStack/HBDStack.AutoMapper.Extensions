using AutoMapper;
using FluentAssertions;
using HBD.AutoMapper.Lazy.Tests.Data;
using Microsoft.Extensions.DependencyInjection;

namespace HBD.AutoMapper.Lazy.Tests;

public class LazyResultTests:IClassFixture<LazyMapFixture>
{
    private readonly LazyMapFixture _fixture;

    public LazyResultTests(LazyMapFixture fixture) => _fixture = fixture;

    [Fact]
    public void LazyMap_Test()
    {
        var mapper = _fixture.ServiceProvider.GetRequiredService<IMapper>();
        var m = new Model("Steven");
        var v = mapper.ResultOf<View>(m);

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
        var v = mapper.ResultOf<Model>(m);

        v.Value.Should().NotBeNull();
        v.Value.Should().Be(m);
    }
    
    [Fact]
    public void LazyMap_NullValue_Test()
    {
        var mapper = _fixture.ServiceProvider.GetRequiredService<IMapper>();
        var v =()=> mapper.ResultOf<Model>(null!);
        v.Should().Throw<ArgumentNullException>();
    }
}