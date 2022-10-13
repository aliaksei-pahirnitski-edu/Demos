namespace DemoCocona.DemoServices
{
    interface IDemoErrorService
    {
        string GetBestCity();
    }

    class DemoErrorService : IDemoErrorService
    {
        public string GetBestCity()
        {
            throw new ApplicationException("Ups.. Error happened..");
        }
    }
}
