
namespace Spike.ConsoleApp
{
    using System.ServiceProcess;
    using System.ComponentModel;
    using Workers;

    [RunInstaller(true)]
    public class SpikeService : ServiceBase
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
    }
}
