using Microsoft.Extensions.Hosting;

namespace MyFunctions.Tests.Infrastructure;

public sealed class TestAppHost : IDisposable
{
    internal readonly IHost Host;

    internal TestAppHost(HostApplicationBuilder builder, Action<IHostApplicationBuilder> configure)
    {
        configure(builder);
        Host = builder.Build();
        Host.StartAsync().GetAwaiter().GetResult();
    }

    internal TestAppHost(IHostBuilder builder, Action<IHostBuilder> configure)
    {
        configure(builder);
        Host = builder.Build();
        Host.StartAsync().GetAwaiter().GetResult();
    }

    public void Dispose() => Host.Dispose();
}