namespace OneWebside;
/// <summary>
/// Webservice Request class that implements IRequest Using HTTPClient to request url Asynchronous and returning Task<string>
/// </summary>
public class WebserviceRequest : IRequest
{
    public async Task<string> GetResponseAsync(string url)
    {
        try
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                HttpResponseMessage responseMessage = await client.GetAsync(url);
                responseMessage.EnsureSuccessStatusCode();

                return await responseMessage.Content.ReadAsStringAsync();
            };
        }
        catch (HttpRequestException e)
        {
            //If request wasnt successfull
            Log.Logger.Error($"{e.Source} | {e.Message}");
            return "Error in the webservice request";
        }
        catch (UriFormatException u)
        {
            //If url isnt a valid uri
            Log.Logger.Error($"uri exception {url}|{u.Source} | {u.Message}");
            return $"Uri was invalid {url}";
        }
        catch (ArgumentNullException a)
        {
            Log.Logger.Error($"Uri empty | {a.Source}|{a.Message}");
            return $"Uri is null";
        }
        catch (Exception e)
        {
            Log.Logger.Error($"{e.Source}|{e.Message}");
            return "Exception";
        }

    }
}
