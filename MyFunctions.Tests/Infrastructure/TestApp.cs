using Microsoft.Extensions.Hosting;

namespace MyFunctions.Tests.Infrastructure;

public class TestApp : HostedAppFactory<Program>
{
    protected override void ConfigureHost(IHostBuilder builder)
    {
        base.ConfigureHost(builder);
    }
}