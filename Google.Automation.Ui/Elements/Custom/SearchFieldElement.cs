using Google.Automation.Ui.Elements.Base;
using Google.Automation.Ui.Elements.Default;
using OpenQA.Selenium;

namespace Google.Automation.Ui.Elements.Custom;

public class SearchFieldElement : BaseWebElement
{
    private readonly By _textAreaLocator = By.TagName("textarea");
    
    public TextArea TextArea => Element.FindChildElement<TextArea>(_textAreaLocator);
}