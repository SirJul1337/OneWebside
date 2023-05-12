namespace OneWebside;
/// <summary>
/// Webservice Request class that implements IRequest Using HTTPClient to request url Asynchronous and returning Task<string>
/// </summary>
public class WebserviceRequest : IRequest
{
    public async Task<string> GetResponseAsync(string url)
    {
        string response = "";
        try
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                HttpResponseMessage responseMessage = await client.GetAsync(url);
                responseMessage.EnsureSuccessStatusCode();

                response = await responseMessage.Content.ReadAsStringAsync();
            };
            return response;
        }
        catch (HttpRequestException e)
        {
            //If request wasnt successfull
            Program.Logger.Error($"{e.Source} | {e.Message}");
            return "Error in the webservice request";
        }
        catch (UriFormatException u)
        {
            //If url isnt a valid uri
            Program.Logger.Error($"uri exception {url}|{u.Source} | {u.Message}");
            return $"Uri was invalid {url}";
        }
        catch (ArgumentNullException a)
        {
            Program.Logger.Error($"Uri empty | {a.Source}|{a.Message}");
            return $"Uri is null";
        }
        catch (Exception e)
        {
            Program.Logger.Error($"{e.Source}|{e.Message}");
            return "Exception";
        }

    }
}
