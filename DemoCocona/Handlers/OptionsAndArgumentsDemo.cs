namespace DemoCocona.Handlers
{
    internal class OptionsAndArgumentsDemo
    {
        /// <summary>
        /// args = "say-hallo --user Kaisa"
        /// </summary>
        public void SayHallo(string user)
        {
            Console.WriteLine("Demo: Hallo " + user);
        }

        /// <summary>
        /// By default params are options
        /// args = "add-numbers-as-options --a 3 --b 4"
        /// </summary>
        public void AddNumbersAsOptions(int a, int b)
        {
            Console.WriteLine($"Demo: {a} + {b} = {a + b}");
        }

        /// <summary>
        /// Uses arguments and adds description
        /// help args = "minus-numbers-as-arguments --help"
        /// args = "minus-numbers-as-arguments 7 5"
        /// </summary>
        public void MinusNumbersAsArguments([Cocona.Argument] int a,
            [Cocona.Argument("b_renamed", Description = "some description")] int b)
        {
            Console.WriteLine($"Demo: {a} - {b} = {a - b}");
        }

        /// <summary>
        /// Renamed and shortcuted options. 
        /// help args = "divide-numbers --help"
        /// args = "divide-numbers -X 24 -Y 8"
        /// args = "divide-numbers -X 36 --divider 2"
        /// </summary>
        public void DivideNumbers([Cocona.Option('X')] int num, [Cocona.Option("divider", new char[] { 'Y' })] int b)
        {
            Console.WriteLine($"Demo: {num} / {b} = {num / b}");
        }
    }
}
