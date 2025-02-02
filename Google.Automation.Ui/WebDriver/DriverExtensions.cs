using OpenQA.Selenium;

namespace Google.Automation.Ui.WebDriver;

public static class DriverExtensions
{
    public static IJavaScriptExecutor JavaScriptExecutor(this IWebDriver driver)
    {
        return (IJavaScriptExecutor)driver;
    }
    
    public static Screenshot TakeScreenshot(this IWebDriver driver)
    {
        return ((ITakesScreenshot)driver).GetScreenshot();
    }
}