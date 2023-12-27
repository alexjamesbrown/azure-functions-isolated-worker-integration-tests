using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MyFunctions.Tests.Infrastructure;

public abstract class HostedAppFactory<T> : IDisposable
{
    private readonly HostApplicationBuilder? _hostAppBuilder;
    private readonly IHostBuilder? _hostBuilder;

    protected HostedAppFactory()
    {
        var entryPoint = typeof(T).Assembly.EntryPoint!.DeclaringType!;

        var locator = new WorkerHostFactoryLocator(entryPoint, CreateBuilderMethodName, Environment);
        _hostAppBuilder = locator.HostApplicationBuilder;
        _hostBuilder = locator.HostBuilder;
    }

    protected virtual void ConfigureApplicationHost(IHostApplicationBuilder builder)
    {
    }

    protected virtual void ConfigureHost(IHostBuilder builder)
    {
    }

    public void Dispose()
    {
        _workerService?.Dispose();
        ServiceScope.Dispose();
        GC.SuppressFinalize(this);
    }

    public TService GetService<TService>()
        where TService : class => ServiceScope.ServiceProvider.GetRequiredService<TService>();

    public void Start() => _ = AppHost;

    private bool TryHostAppBuilder(out TestAppHost service)
    {
        service = default!;

        if (_hostAppBuilder is null)
            return false;

        service = new TestAppHost(_hostAppBuilder, ConfigureApplicationHost);
        return true;
    }

    private bool TryHostBuilder(out TestAppHost service)
    {
        service = default!;

        if (_hostBuilder is null)
            return false;

        service = new TestAppHost(_hostBuilder, ConfigureHost);
        return true;
    }

    protected virtual string CreateBuilderMethodName { get; } = "CreateHostBuilder";
    protected virtual string Environment { get; } = Environments.Development;

    private IServiceScope? _serviceScope;
    private IServiceScope ServiceScope => _serviceScope ??= Services.CreateScope();

    public IServiceProvider Services => AppHost.Host.Services;

    private TestAppHost? _workerService;

    public TestAppHost AppHost =>
        _workerService ??=
            TryHostAppBuilder(out _workerService) || TryHostBuilder(out _workerService)
                ? _workerService
                : throw new Exception("No valid host has been provided.");
}