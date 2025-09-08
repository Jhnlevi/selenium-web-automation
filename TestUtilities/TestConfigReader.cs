using Microsoft.Extensions.Configuration;
using NUnit.Framework;

namespace TestUtilities
{
    public static class TestConfigReader
    {
        // Load the appsettings in appsetting.json file.
        public static T GetAppSettings<T>(
            string fileName = "appsettings.json",
            string sectionName = "AppSettings")
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(TestContext.CurrentContext.TestDirectory)
                .AddJsonFile(fileName, optional: false, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();

            return config.GetSection(sectionName).Get<T>()!;
        }
    }
}
