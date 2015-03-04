
namespace Spike.ConsoleApp
{
    using System.ComponentModel;
    using System.Configuration.Install;
    using System.ServiceProcess;
    using Properties;
    
    [RunInstaller(true)]
    public class ManualServiceInstaller : Installer
    {
        public ManualServiceInstaller()
        {
            var processInstaller = new ServiceProcessInstaller();
            var serviceInstaller = new ServiceInstaller();

            //set the privileges
            processInstaller.Account = ServiceAccount.LocalSystem;

            serviceInstaller.DisplayName = ExampleService.Default.ServiceName;
            serviceInstaller.StartType = ServiceStartMode.Manual;

            //must be the same as what was set in Program's constructor
            serviceInstaller.ServiceName = ExampleService.Default.ServiceName;

            this.Installers.Add(processInstaller);
            this.Installers.Add(serviceInstaller);
        }

    }
}
