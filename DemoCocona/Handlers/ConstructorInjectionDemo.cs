using Cocona;
using DemoCocona.DemoServices;
using System.Diagnostics;

namespace ImageYearSorter.Handlers
{
    /// <summary>
    /// Example how to use cocona Mayuki
    /// help args "--help" or "-h"
    /// Note: do not mix constructor injected services and method services! They are in different scope!
    /// </summary>
    internal class ConstructorInjectionDemo
    {
        private readonly IDemoTransientService _transientService;
        private readonly IDemoScopedService _scopedService;
        private readonly IDemoCompositeService _compositeService;

        public ConstructorInjectionDemo(IDemoTransientService transientService
            , IDemoScopedService scopedService
            , IDemoCompositeService compositeService)
        {
            _transientService = transientService;
            _scopedService = scopedService;
            _compositeService = compositeService;
        }

        /// <summary>
        /// help args = "constructor-transients --help"
        /// args = "cconstructor-transients 100"
        /// </summary>
        public void ConstructorTransients([Argument]int x)
        {
            var discount1 = _transientService.GetDiscount();
            var discount2 = _compositeService.GetTransientValue();
            
            Console.WriteLine($"{nameof(ConstructorTransients)} {discount1} and {discount2} x={x}");
            Debug.Assert(discount1 != discount2);
        }

        /// <summary>
        /// help args = constructor-scoped --help
        /// args = constructor-scoped --comment "Thanks, very interesting!"
        /// </summary>
        public void ConstructorScoped(string? comment)
        {
            // !! Note: do not mix constructor injected services and method scoped services! They are in different scope!
            var price1 = _scopedService.GetFullPrice();
            var price2 = _compositeService.GetScopedValue();
            Console.WriteLine($"ConstructorScoped {price1} and {price2}, comment={comment}");
            Debug.Assert(price1 == price2);
        }
    }
}
