using System.Collections.ObjectModel;
using Google.Automation.Core.Timeouts;
using Google.Automation.Ui.WebDriver;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Exception = System.Exception;

namespace Google.Automation.Ui.Waiters;

public static class WebWaiter
{
    public static void WaitForPageLoad(TimeSpan timeout)
    {
        var wait = new WebDriverWait(Driver.Instance, timeout);
        wait.Until(driver => driver.JavaScriptExecutor().ExecuteScript("return document.readyState").Equals("complete"));
    }
    
    public static IWebElement WaitForElement(
        By locator, TimeSpan? timeout, Func<By, Func<IWebDriver, IWebElement>> condition)
    {
        var wait = new WebDriverWait(Driver.Instance, timeout ?? CustomTimeout.TwoSecondsTimeout);
        
        return wait.Until(condition(locator));
    }

    public static List<IWebElement> WaitForElements(
        By locator, TimeSpan? timeout, Func<By, Func<IWebDriver, ReadOnlyCollection<IWebElement>>> condition)
    {
        List<IWebElement> elements;
        var wait = new WebDriverWait(Driver.Instance, timeout ?? CustomTimeout.TwoSecondsTimeout);
        try
        {
            elements = wait.Until(condition(locator)).ToList();
        }
        catch (Exception)
        {
            elements = [];
        }
        
        return elements;
    }
    
    public static IWebElement WaitForChildElement(
        IWebElement parent, By locator, TimeSpan? timeout, Func<By, Func<IWebDriver, IWebElement>> condition)
    {
        var driver = ((IWrapsDriver)parent).WrappedDriver;
        var wait = new WebDriverWait(driver, timeout ?? CustomTimeout.TwoSecondsTimeout);
    
        return wait.Until(condition(locator));
    }
    
    public static List<IWebElement> WaitForChildElements(
        IWebElement parent, By locator, TimeSpan? timeout, Func<By, Func<IWebDriver, ReadOnlyCollection<IWebElement>>> condition)
    {
        var driver = ((IWrapsDriver)parent).WrappedDriver;
        List<IWebElement> elements;
        var wait = new WebDriverWait(driver, timeout ?? CustomTimeout.TwoSecondsTimeout);
        try
        {
            elements = wait.Until(condition(locator)).ToList();
        }
        catch (Exception)
        {
            elements = [];
        }
        
        return elements;
    }
}