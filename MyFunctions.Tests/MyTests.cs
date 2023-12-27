using MyFunctions.Tests.Infrastructure;
using Xunit;

namespace MyFunctions.Tests;

public class MyHttpTriggerTests
{
    private readonly HostedAppFactory<Program> _hostedAppFactory;

    public MyHttpTriggerTests()
    {
        _hostedAppFactory = new TestApp();
        _hostedAppFactory.Start();
    }

    [Fact]
    public void GetRequest_ReturnsHttpOkAndExpectedText()
    {
        // 1) create http client
        // 2) fire GET request
        // 3) assert response is ok + contains "Welcome to Azure Functions!"
    }
}