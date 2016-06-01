using EcentricHPP.Enum;
using System.Configuration;

namespace EcentricHPP.Helpers
{
    public static class ConfigHelper
    {
        public static string GetConfiguration(Config key)
        {
            var configValues =  ConfigurationManager.AppSettings.GetValues(key.ToString());
            return configValues == null ? "" : configValues[0];
        }

        public static string HPPLink()
        {
            var configValues = ConfigurationManager.AppSettings.GetValues("HPPLink");
            return configValues[0];
        }
    }
}