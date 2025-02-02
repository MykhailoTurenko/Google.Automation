using OpenQA.Selenium;

namespace Google.Automation.Ui.WebDriver.Factory;

public interface IDriverFactory
{
    public IWebDriver CreateDriver();
}