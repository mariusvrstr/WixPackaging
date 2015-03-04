
namespace Spike.ConsoleApp
{
    using System;
    using System.ComponentModel;
    using System.ServiceProcess;
    using Workers;

    [RunInstaller(true)]
    public class Program : ServiceBase
    {
        protected override void OnStart(string[] args)
        {
            base.OnStart(args);

            new JobManager().Start();
        }

        protected override void OnStop()
        {
            base.OnStop();

            FileWorker.RemoveFile(JobManager.FilePath);
        } 

        public static void Main(string[] args)
        {
            Run(new Program());
            Console.ReadKey();
        }
    }
}
