using Microsoft.Extensions.DependencyInjection;
using SolidToken.SpecFlow.DependencyInjection;

namespace WA_automator.AcceptanceTests.Steps;

public static class TestDependencies
{
    [ScenarioDependencies]
    public static IServiceCollection CreateServices()
    {
        var services = new ServiceCollection();

        services.AddTransient<IBrowserController, BrowserController>();

        return services;
    }
}