namespace DemoCocona.DemoServices
{
    interface IDemoScopedService
    {
        int GetFullPrice();
    }

    public class DemoScopedService : IDemoScopedService
    {
        private static int s_counter = 0;
        public int Id { get; }

        private int m_price;

        public DemoScopedService()
        {
            s_counter++;
            Id = s_counter;
            m_price = Random.Shared.Next(100, 990);
            Console.WriteLine($"Created Scoped {Id}");
        }

        public int GetFullPrice()
        {
            Console.WriteLine($"Scoped[{Id}] full price: {m_price}");
            return m_price;
        }
    }
}
