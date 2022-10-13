namespace DemoCocona.DemoServices
{
    interface IDemoTransientService
    {
        double GetDiscount();
    }

    public class DemoTransientService : IDemoTransientService
    {
        private static int s_counter = 0;
        public int Id { get; }
        private double m_discount;

        public DemoTransientService()
        {
            s_counter++;
            Id = s_counter;
            m_discount = Math.Round(Random.Shared.NextDouble(), 3);
            Console.WriteLine($"Created {nameof(DemoTransientService)} {Id}");
        }

        public double GetDiscount()
        {
            Console.WriteLine($"{nameof(DemoTransientService)}[{Id}] discount: {m_discount}");
            return m_discount;
        }
    }
}
