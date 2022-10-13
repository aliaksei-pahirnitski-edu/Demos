namespace DemoCocona.DemoServices
{
    interface IDemoAsyncService
    {
        Task<int> FetchProductsCount();
    }

    class DemoAsyncService : IDemoAsyncService
    {
        public async Task<int> FetchProductsCount()
        {
            await Task.Delay(1200); // call some external API
            return 12345;
        }
    }
}
