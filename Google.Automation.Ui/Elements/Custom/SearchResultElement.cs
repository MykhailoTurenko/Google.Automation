using Google.Automation.Ui.Elements.Base;
using Google.Automation.Ui.Elements.Default;
using OpenQA.Selenium;

namespace Google.Automation.Ui.Elements.Custom;

public class SearchResultElement : BaseWebElement
{
    private readonly By _linkLocator = By.XPath("//a[@jsname='UWckNb']");
    
    public Link Link => Element.FindChildElement<Link>(_linkLocator);
}