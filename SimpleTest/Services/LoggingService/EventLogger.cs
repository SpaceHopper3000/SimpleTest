using System.Diagnostics;
namespace SimpleTest.Services.LoggingService;

public class EventLogger : ILogger
{
    public void Log(string message)
    {
        const string sourceName = "SimpleTest";
        var myLogName = "SimpleTestLog";
        const string messageFile = "custom.log";
    
        if (!EventLog.SourceExists(sourceName))
        {
            var mySourceData = new EventSourceCreationData(sourceName, myLogName)
            {
                MessageResourceFile = messageFile,
                CategoryResourceFile = messageFile,
                CategoryCount = 1,
                ParameterResourceFile = messageFile
            };
            EventLog.CreateEventSource(mySourceData);
        }

        myLogName = EventLog.LogNameFromSourceName(sourceName,".");

        using var eventLog = new EventLog(myLogName, ".", sourceName);
        eventLog.Source = sourceName;
        eventLog.WriteEntry(message);
    }
}