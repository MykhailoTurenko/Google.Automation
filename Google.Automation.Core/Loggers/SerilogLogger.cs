using Serilog;

namespace Google.Automation.Core.Loggers;

public class SerilogLogger(string name)
{
    public static void InitLogger()
    {
        Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .CreateLogger();
    }

    public void Debug(string message)
    {
        Log.Debug(GetFormattedMessage(message));
    }
    
    public void Info(string message)
    {
        Log.Information(GetFormattedMessage(message));
    }
    
    public void Warning(string message)
    {
        Log.Warning(GetFormattedMessage(message));
    }
    
    public void Error(string message, Exception exception)
    {
        Log.Error(exception, GetFormattedMessage(message));
    }
    
    public void Error(string message)
    {
        Log.Error(message);
    }
    
    private string GetFormattedMessage(string message)
    {
        return $"[{name}] {message}";
    }
}