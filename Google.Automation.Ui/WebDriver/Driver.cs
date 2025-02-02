using Google.Automation.Ui.Elements.Base;
using Google.Automation.Ui.Waiters;
using Google.Automation.Ui.WebDriver.Factory;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace Google.Automation.Ui.WebDriver;

public static class Driver
{
    private static readonly IDriverFactory DriverFactory;
    private static readonly ThreadLocal<IWebDriver?> Drivers = new();

    static Driver()
    {
        DriverFactory = DriverFactorySelector.GetDriverFactory();
    }

    public static IWebDriver Instance => 
        Drivers.Value ?? (Drivers.Value = DriverFactory.CreateDriver());

    public static void ClearCookies()
    {
        Instance.Manage().Cookies.DeleteAllCookies();
    }
    
    public static void DeleteDriver()
    {
        if (Drivers.Value != null)
        {
            Drivers.Value.Quit();
            Drivers.Value = null;
        }
    }
    
    public static T FindElement<T>(By locator, TimeSpan? timeout = null) where T : BaseWebElement, new()
    {
        var webElement = new T
        {
            Element = WebWaiter.WaitForElement(locator, timeout, ExpectedConditions.ElementExists)
        };

        return webElement;
    }
    
    public static List<T> FindElements<T>(By locator, TimeSpan? timeout = null) where T : BaseWebElement, new()
    {
        var webElements = WebWaiter.WaitForElements(locator, timeout, ExpectedConditions.PresenceOfAllElementsLocatedBy)
            .Select(webElement => new T { Element = webElement })
            .ToList();

        return webElements;
    }
}