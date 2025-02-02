using Microsoft.Extensions.Configuration;

namespace Google.Automation.Core.Configurations;

public static class Configuration
{
    public static string Browser { get; set; }
    public static string Host { get; set; }
    
    public static void Configure()
    {
        var configurationFilesPath = Path.Combine(Directory.GetCurrentDirectory(), "Configurations", "Files");
        IConfigurationBuilder builder = new ConfigurationBuilder().SetBasePath(configurationFilesPath);
        builder = builder.AddJsonFile("appSettings.json");
        IConfigurationRoot configuration = builder.Build();
        
        Browser = configuration.GetSection("Browser").Value;
        
        string? environment  = configuration.GetSection("Environment").Value;
        builder.Sources.Clear();
        builder.AddJsonFile($"{environment.ToLower()}Configs.json");
        configuration = builder.Build();
        
        Host = configuration.GetSection("Host").Value;
    }
}