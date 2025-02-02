using Google.Automation.Ui.Elements.Custom;
using Google.Automation.Ui.Pages.Base;
using Google.Automation.Ui.WebDriver;
using OpenQA.Selenium;

namespace Google.Automation.Ui.Pages;

public class ResultsPage() : BasePage(nameof(ResultsPage))
{
    private readonly By _resultsLocator = By.XPath("//div[@jscontroller='SC7lYd']");

    public override void WaitPageIsReady()
    {
        base.WaitPageIsReady();
        var pageSource = GetPageSource();
        if (pageSource.Contains("captcha-form"))
        {
            var exception = new Exception("Captcha is displayed. Please recheck the environment test availability!");
            Logger.Error("Not possible to perform any actions", exception);
            throw exception;
        }
    }

    public string GetFirstLinkTexts()
    {
        return GetResultsElements().First().Link.GetText();
    }

    public bool IsResultsDisplayed()
    {
        return GetResultsElements().Count > 0;
    }
    
    private List<SearchResultElement> GetResultsElements()
    {
        return Driver.FindElements<SearchResultElement>(_resultsLocator);
    }
}