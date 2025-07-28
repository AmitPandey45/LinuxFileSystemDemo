using Microsoft.Extensions.Configuration;

namespace LinuxFileSystemDemo
{
    public static class ConfigReader
    {
        public static IConfigurationRoot LoadConfig(string appSettingsPath = "appsettings.json")
        {
            return new ConfigurationBuilder()
              .AddJsonFile(appSettingsPath, optional: false, reloadOnChange: false)
              .Build();
        }

        public static string GetValue(string key, string defaultAppSettingsFileName = "appsettings.json")
        {
            return LoadConfig(defaultAppSettingsFileName)[key];
        }
    }
}
