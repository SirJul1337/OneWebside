namespace OneWebside;

/// <summary>
/// Interface for GetResponseAsync, that will be implemented in RequestServices
/// </summary>
public interface IRequest
{
    public Task<string> GetResponseAsync(string url);
}
