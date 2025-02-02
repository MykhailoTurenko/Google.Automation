using Google.Automation.Ui.Elements.Base;

namespace Google.Automation.Ui.Elements.Default;

public class TextArea : BaseWebElement
{
    public void Fill(string text)
    {
        Element.SendKeys(text);
    }
    
    public void PressKey(string key)
    {
        Element.SendKeys(key);
    }
}