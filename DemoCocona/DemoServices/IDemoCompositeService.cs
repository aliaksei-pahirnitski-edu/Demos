namespace DemoCocona.DemoServices
{
    /// <summary>
    /// Demo shows in implementation that other services injected
    /// </summary>
    interface IDemoCompositeService
    {
        double GetTransientValue();
        int GetScopedValue();
        int GetPrice();
    }

    class DemoCompositeService : IDemoCompositeService
    {
        private readonly IDemoTransientService _transientDiscountService;
        private readonly IDemoScopedService _scopedPriceService;

        public DemoCompositeService(IDemoTransientService transientDiscountService,
            IDemoScopedService scopedPriceService)
        {
            _transientDiscountService = transientDiscountService;
            _scopedPriceService = scopedPriceService;
        }

        public int GetPrice()
        {
            var originalPrice = _scopedPriceService.GetFullPrice();
            var discount = _transientDiscountService.GetDiscount();
            return (int)Math.Floor(originalPrice * (1 - discount));
        }

        public int GetScopedValue() => _scopedPriceService.GetFullPrice();

        public double GetTransientValue() => _transientDiscountService.GetDiscount();
    }
}
