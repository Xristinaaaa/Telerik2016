using Dealership.Engine;
using Ninject;
using System.Reflection;

namespace Dealership
{
    public class Startup
    {
        public static void Main()
        {
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());
            kernel.Get<IEngine>().Start();
        }
    }
}
