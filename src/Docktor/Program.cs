using DataModel.Configuration;

namespace Docktor
{
    class Program
    {
        static void Main(string[] args)
        {
            Configuration config = new Configuration();
            Docktor d = new Docktor(config);
            d.Run();
        }
    }
}
