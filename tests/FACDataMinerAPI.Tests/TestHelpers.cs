using DotNetEnv;

namespace FACDataMinerAPI.Tests;

public class TestHelpers
{
    private static readonly HttpClient _httpClient;
    
    static TestHelpers()
    {
        Env.TraversePath().Load();
        _httpClient = new HttpClient();
    }
    
    public static string GetAPIKey()
    {
        return Env.GetString("api_token");
    }
    
    public static Uri GetAPIEndpoint()
    {
        return new Uri(Env.GetString("api_endpoint"));
    }

    public static HttpClient GetHttpClient()
    {
        return _httpClient;
    }

    public static StandardAPIServiceArguments CreateStandardApiTestApiServiceArguments(int desiredRecordCount)
    {
        string apiKey = GetAPIKey();
        Uri apiEndPoint = GetAPIEndpoint();
        HttpClient httpClient = GetHttpClient();

        return new StandardAPIServiceArguments(apiEndPoint, apiKey, httpClient, desiredRecordCount);
        
    }
    
}