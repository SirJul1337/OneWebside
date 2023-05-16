using OneWebside;
using Serilog;

public class Program
{

    public static void Main()
    {

        //Instaciating manager
        Manager manager = new Manager();
        
        //Instaciating request services
        WebserviceRequest webRequest = new WebserviceRequest();
        FileRequest fileRequest = new FileRequest();
        
        //Setting request service on manager to webRequest service
        manager.SetRequestService(webRequest);
        //Starting request in manager with an url, and writing response in console
        Console.WriteLine(manager.StartRequest(null));

        //Setting request service on manager to fileRequest service
        manager.SetRequestService(fileRequest);
        //starting request in manager with file path, and writing response in console
        Console.WriteLine(manager.StartRequest("TestFile.txt"));
    } 
}