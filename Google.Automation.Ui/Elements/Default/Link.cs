using Google.Automation.Ui.Elements.Base;
using OpenQA.Selenium;

namespace Google.Automation.Ui.Elements.Default;

public class Link : BaseWebElement
{
    private readonly By _textLocator = By.TagName("h3");
    
    public string GetText()
    {
        return Element.FindElement(_textLocator).Text;
    }
}