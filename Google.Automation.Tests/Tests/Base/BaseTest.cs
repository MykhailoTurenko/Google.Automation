using Allure.Net.Commons;
using Google.Automation.Core.Configurations;
using Google.Automation.Core.Loggers;
using Google.Automation.Ui.WebDriver;
using NUnit.Framework;
using NUnit.Framework.Interfaces;

namespace Google.Automation.Tests.Tests.Base;

public class BaseTest
{
    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        Configuration.Configure();
        SerilogLogger.InitLogger();
    }
    
    [SetUp]
    public void SetUp()
    {
        Driver.ClearCookies();
    }
    
    [TearDown]
    public void TearDown()
    {
        var testStatus = TestContext.CurrentContext.Result.Outcome.Status;
        try
        {
            if (testStatus == TestStatus.Failed)
            {
                var screenshot = Driver.Instance.TakeScreenshot();
                AllureApi.AddAttachment("Failure Screenshot", "image/jpeg", screenshot.AsByteArray, "jpeg");
            }
        }
        finally
        {
            Driver.DeleteDriver();
        }
    }
}