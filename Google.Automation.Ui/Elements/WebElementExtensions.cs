using Google.Automation.Ui.Elements.Base;
using Google.Automation.Ui.Waiters;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace Google.Automation.Ui.Elements;

public static class WebElementExtensions
{
    public static T FindChildElement<T>(this IWebElement parent, By locator, TimeSpan? timeout = null) 
        where T : BaseWebElement, new()
    {
        T webElement = new()
        {
            Element = WebWaiter.WaitForChildElement(parent, locator, timeout, ExpectedConditions.ElementExists)
        };

        return webElement;
    }
    
    public static List<T> FindChildElements<T>(this IWebElement parent, By locator, TimeSpan? timeout = null) 
        where T : BaseWebElement, new()
    {
        var webElements = WebWaiter.WaitForChildElements(
                parent, locator, timeout, ExpectedConditions.PresenceOfAllElementsLocatedBy)
            .Select(webElement => new T { Element = webElement })
            .ToList();

        return webElements;
    }
}