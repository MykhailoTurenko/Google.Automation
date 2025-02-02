using Google.Automation.Core.Configurations;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace Google.Automation.Ui.WebDriver.Factory;

public class FirefoxDriverFactory : IDriverFactory
{
    public IWebDriver CreateDriver()
    {
        var properties = new FirefoxOptions();
        properties.AddArgument("start-maximize");
        properties.AddArgument("disable-extensions");
        properties.AddArgument("disable-popup-blocking");
        properties.AddArgument("disable-infobars");
        if (Configuration.RemoteRun)
            properties.AddArgument("--headless");
        
        new DriverManager().SetUpDriver(new FirefoxConfig());
        
        return new FirefoxDriver(properties);
    }
}