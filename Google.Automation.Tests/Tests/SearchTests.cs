using Allure.NUnit;
using Allure.NUnit.Attributes;
using FluentAssertions;
using Google.Automation.Tests.Tests.Base;
using Google.Automation.Ui.Pages;
using NUnit.Framework;

namespace Google.Automation.Tests.Tests;

[TestFixture]
[AllureNUnit]
[AllureSuite("Search")]
public class SearchTests : BaseTest
{
    [TestCase("Selenium C# tutorial", "Selenium")]
    [AllureDescription("Search by text '{searchText}' and check that the first result contains '{expectedText}'")]
    public void Search_FirstResult_ShouldContainsText(string searchText, string expectedText)
    {
        var homePage = new HomePage();
        homePage.OpenPage();
        
        homePage.SearchByPressEnter(searchText);
        
        var resultsPage = new ResultsPage();
        resultsPage.WaitPageIsReady();
        
        var isResultsDisplayed = resultsPage.IsResultsDisplayed();
        isResultsDisplayed.Should().BeTrue();
        
        var firstLinkTexts = resultsPage.GetFirstLinkTexts();
        firstLinkTexts.Should().Contain(expectedText);
    }
}