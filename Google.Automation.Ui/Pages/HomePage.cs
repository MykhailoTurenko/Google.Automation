using Google.Automation.Ui.Elements.Custom;
using Google.Automation.Ui.Pages.Base;
using Google.Automation.Ui.WebDriver;
using OpenQA.Selenium;

namespace Google.Automation.Ui.Pages;

public class HomePage() : BasePage(nameof(HomePage))
{
    private readonly By _searchFieldLocator = By.ClassName("RNNXgb");

    public void OpenPage()
    {
        OpenAndWaitPageIsReady(string.Empty);
    }
    
    public void SearchByPressEnter(string text)
    {
        Logger.Info($"Search by press the Enter button with text '{text}'");
        var searchField = Driver.FindElement<SearchFieldElement>(_searchFieldLocator);
        searchField.TextArea.Fill(text);
        searchField.TextArea.PressKey(Keys.Enter);
    }
}