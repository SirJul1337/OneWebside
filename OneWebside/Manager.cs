namespace OneWebside;
public class Manager
{
    private IRequest requestService;
    /// <summary>
    /// Method for setting the the request service, a class where the IRequest is implemented
    /// </summary>
    /// <param name="r"></param>
    public void SetRequestService(IRequest r)
    {
        requestService = r;
    }
    /// <summary>
    /// Method to start Request on the Requestservice with an url, and returning the result string
    /// </summary>
    /// <param name="url"></param>
    /// <returns></returns>
    public string StartRequest(string url)
    {
        return requestService.GetResponseAsync(url).Result;
    }
}
