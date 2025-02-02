using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace Google.Automation.Ui.WebDriver.Factory;

public class ChromeDriverFactory : IDriverFactory
{
    public IWebDriver CreateDriver()
    {
        var properties = new ChromeOptions();
        properties.AddArgument("start-maximized");
        properties.AddArgument("disable-extensions");
        properties.AddArgument("disable-popup-blocking");
        properties.AddArgument("disable-infobars");
        properties.AddArgument("--no-sandbox");
        
        new DriverManager().SetUpDriver(new ChromeConfig());
        
        return new ChromeDriver(properties);
    }
}