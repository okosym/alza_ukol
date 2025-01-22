using System.Text;

namespace AlzaUkol.Api.Tests;

public class TestJsonUtils
{
    public static string GetJson(string path)
    {
        string currentDir = Directory.GetCurrentDirectory();
        string fullFilename = @$"{currentDir}\{path}";
        string json = File.ReadAllText(fullFilename);
        return json;
    }

    public static StringContent GetJsonBody(string path)
    {
        string json = GetJson(path);
        StringContent jsonBody = CreateJsonBody(json);
        return jsonBody;
    }

    public static StringContent CreateJsonBody(string json)
    {
        StringContent jsonBody = new StringContent(json, Encoding.UTF8, "application/json");
        return jsonBody;
    }
}
