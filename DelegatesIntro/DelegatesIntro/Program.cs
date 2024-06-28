
using System.Numerics;

class Program
{
    delegate void LogDel(string msg);
    static void Main(string[] args)
    {
        Log log = new Log();
        LogDel logTextToScreen = new LogDel(log.LogTextToScreen);
        LogDel logTextToFile = new LogDel(log.LogTextToFile);

        LogDel multiLog = logTextToScreen + logTextToFile;
        LogText(multiLog, "message");
    }

    static void LogText(LogDel logDel,string msg)
    {
        logDel(msg);
    }

}

public class Log
{
    public void LogTextToScreen(string msg)
    {
        Console.WriteLine($"{DateTime.Now} : {msg}");
    }

    public void LogTextToFile(string msg)
    {
        using (StreamWriter sw = new StreamWriter(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Log.text"), true))
        {
            sw.WriteLine($"{DateTime.Now} : {msg}");
        }
    }
}
