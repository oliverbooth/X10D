using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using X10D.Hosting.DependencyInjection;

namespace X10D.Tests.Hosting;

[TestClass]
public class ServiceCollectionTests
{
    [TestMethod]
    public void AddHostedSingleton_ShouldRegisterServiceAsSingletonAndAsHostedService()
    {
        var services = new ServiceCollection();

        services.AddHostedSingleton<TestService>();

        var serviceProvider = services.BuildServiceProvider();
        var service = serviceProvider.GetService<TestService>();
        var hostedService = serviceProvider.GetService<IHostedService>();

        Assert.IsNotNull(service);
        Assert.IsNotNull(hostedService);
        Assert.IsInstanceOfType(service, typeof(TestService));
        Assert.IsInstanceOfType(hostedService, typeof(TestService));
        Assert.AreSame(service, hostedService);
    }

    [TestMethod]
    public void AddHostedSingleton_ShouldRegisterServiceTypeAsSingletonAndAsHostedService()
    {
        var services = new ServiceCollection();

        services.AddHostedSingleton(typeof(TestService));

        var serviceProvider = services.BuildServiceProvider();
        var service = serviceProvider.GetService<TestService>();
        var hostedService = serviceProvider.GetService<IHostedService>();

        Assert.IsNotNull(service);
        Assert.IsNotNull(hostedService);
        Assert.IsInstanceOfType(service, typeof(TestService));
        Assert.IsInstanceOfType(hostedService, typeof(TestService));
        Assert.AreSame(service, hostedService);
    }

    private sealed class TestService : IHostedService
    {
        public Task StartAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
