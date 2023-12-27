using Microsoft.Extensions.Hosting;

var builder = MyFunctions.Program.CreateHostBuilder();
var host = builder.Build();
host.Run();

namespace MyFunctions
{
    public sealed partial class Program
    {
        public static IHostBuilder CreateHostBuilder()
        {
            return new HostBuilder()
                .ConfigureFunctionsWorkerDefaults();
        }
    }
}