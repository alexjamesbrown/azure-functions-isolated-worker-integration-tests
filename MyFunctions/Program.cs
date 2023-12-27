using Microsoft.Extensions.Hosting;

var builder = CreateHostBuilder();
var host = builder.Build();
host.Run();

public sealed partial class Program
{
    public static IHostBuilder CreateHostBuilder()
    {
        return new HostBuilder()
            .ConfigureFunctionsWorkerDefaults();
    }
}