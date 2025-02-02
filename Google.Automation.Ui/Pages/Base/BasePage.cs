using Google.Automation.Core.Configurations;
using Google.Automation.Core.Loggers;
using Google.Automation.Core.Timeouts;
using Google.Automation.Ui.Waiters;
using Google.Automation.Ui.WebDriver;

namespace Google.Automation.Ui.Pages.Base;

public abstract class BasePage(string name)
{
    protected readonly SerilogLogger Logger = new(name);

    public virtual void WaitPageIsReady()
    {
        Logger.Info("Wait until page is ready");
        WebWaiter.WaitForPageLoad(CustomTimeout.TwoSecondsTimeout);
    }
    
    protected void OpenAndWaitPageIsReady(string path)
    {
        Logger.Info($"Navigate to '{Configuration.Host + path}'");
        Driver.Instance.Navigate().GoToUrl(Configuration.Host + path);
        WaitPageIsReady();
    }
    
    protected string GetPageSource()
    {
        return Driver.Instance.PageSource;
    }
}