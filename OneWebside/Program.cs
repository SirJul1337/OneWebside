using OneWebside;
using Serilog;

public class Program
{
    public static ILogger Logger { get; private set; }
    public static void Main()
    {
        Logger = new LoggerConfiguration()
        .WriteTo.File("log.txt")
        .CreateLogger();
        //Instaciating manager
        Manager manager = new Manager();
        
        //Instaciating request services
        WebserviceRequest webRequest = new WebserviceRequest();
        FileRequest fileRequest = new FileRequest();
        
        //Setting request service on manager to webRequest service
        manager.SetRequestService(webRequest);
        //Starting request in manager with an url, and writing response in console
        Console.WriteLine(manager.StartRequest("https://jsonplaceholder.typicode.com/todos/1"));

        //Setting request service on manager to fileRequest service
        manager.SetRequestService(fileRequest);
        //starting request in manager with file path, and writing response in console
        Console.WriteLine(manager.StartRequest("TestFile.txt"));
    } 
}