using System.Security.Authentication.ExtendedProtection;
using Microsoft.Extensions.DependencyInjection;

namespace HBD.AutoMapper.Lazy.Tests;

public sealed class LazyMapFixture:IDisposable,IAsyncDisposable
{
    public ServiceProvider ServiceProvider { get; }
    
    public LazyMapFixture()
    {
        ServiceProvider = new ServiceCollection()
            .AddAutoMapper(typeof(LazyMapFixture).Assembly)
            .BuildServiceProvider();
    }

    public void Dispose() => ServiceProvider.Dispose();
    public ValueTask DisposeAsync() => ServiceProvider.DisposeAsync();
}