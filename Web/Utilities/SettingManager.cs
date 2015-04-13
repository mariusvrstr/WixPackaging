
namespace Spike.Web.Utilities
{
    using System.Configuration;

    public class SettingManager
    {
        private static SettingManager _instance;

        public string Environment { get; set; }
        

        public static SettingManager Instance
        {
            get { return _instance ?? (_instance = new SettingManager().Inititalize()); }
        }

        private SettingManager Inititalize()
        {
            Environment = ConfigurationManager.AppSettings["Environment"] ?? string.Empty;
            
            return this;
        }

        public static void ResetSettings()
        {
            _instance = null;
        }

    }
}