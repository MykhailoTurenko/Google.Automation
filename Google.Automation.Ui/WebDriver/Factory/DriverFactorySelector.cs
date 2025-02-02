using Google.Automation.Core.Configurations;

namespace Google.Automation.Ui.WebDriver.Factory;

public static class DriverFactorySelector
{
    public static IDriverFactory GetDriverFactory()
    {
        var browser = Enum.Parse<Browser>(Configuration.Browser);
        
        return browser switch
        {
            Browser.Chrome => new ChromeDriverFactory(),
            Browser.Firefox => new FirefoxDriverFactory(),
            Browser.Edge => new EdgeDriverFactory(),
            _ => throw new NotSupportedException($"Browser {browser} is not supported")
        };
    }
}