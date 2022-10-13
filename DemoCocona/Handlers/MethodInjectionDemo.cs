using DemoCocona.DemoServices;
using System.Diagnostics;

namespace DemoCocona.Handlers;

/// <summary>
/// Example how to use cocona Mayuki
/// help args "--help" or "-h"
/// Note: do not mix constructor injected services and method services! They are in different scope!
/// </summary>
internal class MethodInjectionDemo
{
    public MethodInjectionDemo()
    {
    }

    /// <summary>
    /// help args = "demo-transients --help"
    /// args = "demo-transients"
    /// </summary>
    public void DemoTransients(
        [Cocona.FromService] IDemoTransientService transient, 
        [Cocona.FromService] IDemoCompositeService composit)
    {
        var discount1 = transient.GetDiscount();
        var discount2 = composit.GetTransientValue();
        Console.WriteLine($"DemoTransients {discount1} and {discount2}");
        Debug.Assert(discount1 != discount2);
    }

    /// <summary>
    /// Works NOT as expected! Scoped service is created again!
    /// help args = "demo-scoped --help"
    /// args = "demo-scoped"
    /// </summary>
    public void DemoScoped([Cocona.FromService] IDemoScopedService scoped
        , [Cocona.FromService] IDemoCompositeService composit)
    {
        // !!  do not mix constructor injected services and method services! They are in different scope!
        var price1 = scoped.GetFullPrice();
        var price2 = composit.GetScopedValue();
        Console.WriteLine($"DemoScoped {price1} and {price2}");
        Debug.Assert(price1 == price2);
    }

    /// <summary>
    /// Error appening 
    /// help args = "demo-async --help"
    /// args = "demo-async"
    /// </summary>
    public async Task DemoAsync([Cocona.FromService] IDemoAsyncService asyncService)
    {
        Console.WriteLine($"DemoAsync starting");
        var result = await asyncService.FetchProductsCount();
        Console.WriteLine($"DemoAsync finished {result}");
    }

    /// <summary>
    /// Error appening 
    /// help args = "demo-error --help"
    /// args = "demo-error 25"
    /// </summary>
    public void DemoError([Cocona.Argument] int demoArg, [Cocona.FromService] IDemoErrorService failingService)
    {
        Console.WriteLine($"Demo before error: demoArg={demoArg} failingService={failingService}");
        var city = failingService.GetBestCity();
        Console.WriteLine($"You will not see city {city}");
    }
}
