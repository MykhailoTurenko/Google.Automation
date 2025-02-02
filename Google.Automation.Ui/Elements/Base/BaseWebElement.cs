using OpenQA.Selenium;

namespace Google.Automation.Ui.Elements.Base;

public abstract class BaseWebElement
{
    public IWebElement Element { get; init; }
}