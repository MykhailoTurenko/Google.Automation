using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace Google.Automation.Ui.WebDriver.Factory;

public class EdgeDriverFactory : IDriverFactory
{
    public IWebDriver CreateDriver()
    {
        var properties = new EdgeOptions();
        properties.AddArgument("start-maximize");
        properties.AddArgument("disable-extensions");
        properties.AddArgument("disable-popup-blocking");
        properties.AddArgument("disable-infobars");

        new DriverManager().SetUpDriver(new EdgeConfig());

        return new EdgeDriver(properties);
    }
}