namespace OneWebside;
/// <summary>
/// FileRequest class to read all text asynchronous and returning Task<string>
/// </summary>
public class FileRequest : IRequest
{
    public async Task<string> GetResponseAsync(string filepath)
    {
		try
		{
			return await File.ReadAllTextAsync(filepath);
		}
        catch (FileNotFoundException f)
        {
			Program.Logger.Error($"File doesnt exist {f.Source} | {f.Message}");
			return "File doesnt exists";
        }
        catch (Exception e)
		{	
			if (filepath == string.Empty)
			{
				Program.Logger.Error($"Filepath was empty{filepath}");
				return "Filepath is empty";
			}
			else
			{
				Program.Logger.Error($"{e.Source} | {e.Message}");
				return "Error occured";
			}
		}

    }
}
