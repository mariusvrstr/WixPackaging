
using System.ServiceProcess;

namespace Spike.ConsoleApp
{
    using System;
    using Workers;

    public class Program
    {

        public static void Main(string[] args)
        {

#if DEBUG
            new JobManager().Start();
            Console.ReadKey();
#else
            var service = new SpikeService();
            ServiceBase.Run(service);
#endif

        }
    }
}
