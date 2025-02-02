using Microsoft.Extensions.Configuration;

namespace Google.Automation.Core.Configurations;

public static class Configuration
{
    private static string TestEnvironment { get; set; }
    public static string Browser { get; set; }
    public static string Host { get; set; }
    
    public static void Configure()
    {
        string configurationFilesPath = Path.Combine(Directory.GetCurrentDirectory(), "Configurations", "Files");
        IConfigurationBuilder builder = new ConfigurationBuilder().SetBasePath(configurationFilesPath);
        IConfigurationRoot configuration;
        
        if (Environment.GetEnvironmentVariable("REMOTE_RUN") is not null)
        {
            TestEnvironment = Environment.GetEnvironmentVariable("ENVIRONMENT");
            Browser = Environment.GetEnvironmentVariable("BROWSER");
        }
        else
        {
            configuration = builder.AddJsonFile("appSettings.json").Build();
            
            Browser = configuration.GetSection("Browser").Value;
            TestEnvironment  = configuration.GetSection("Environment").Value;
        }
        
        configuration = builder.AddJsonFile($"{TestEnvironment.ToLower()}Configs.json").Build();
        
        Host = configuration.GetSection("Host").Value;
    }
}