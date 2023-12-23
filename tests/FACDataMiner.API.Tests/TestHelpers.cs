
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace FACDataMinerAPI.Tests;

public class TestHelpers
{
    private static readonly HttpClient _httpClient;
    private static readonly string _api_key;
    private static readonly string _api_endpoint;
    
    static TestHelpers()
    {
        _httpClient = new HttpClient();
        
        SetEnvironmentVariablesFromUserSecrets();
        
        _api_key = Environment.GetEnvironmentVariable("API_TOKEN") ?? string.Empty;
        _api_endpoint = Environment.GetEnvironmentVariable("API_ENDPOINT") ?? string.Empty;

    }
    
    public static string GetAPIKey()
    {
        return _api_key.Substring(0, 40);
    }
    
    public static Uri GetAPIEndpoint()
    {
        return new Uri(_api_endpoint);
    }

    public static HttpClient GetHttpClient()
    {
        return _httpClient;
    }

    public static StandardAPIServiceArguments CreateStandardApiTestApiServiceArguments(int? desiredRecordCount = null)
    {
        string apiKey = GetAPIKey();
        Uri apiEndPoint = GetAPIEndpoint();
        HttpClient httpClient = GetHttpClient();

        if (desiredRecordCount.HasValue)
        {
            return new StandardAPIServiceArguments(apiEndPoint, apiKey, httpClient, desiredRecordCount);
        }
        else
        {
            return new StandardAPIServiceArguments(apiEndPoint, apiKey, httpClient);
        }
    }
    
    
    static void SetEnvironmentVariablesFromUserSecrets()
    {
        var config = new ConfigurationBuilder().AddUserSecrets<TestHelpers>().Build();
        foreach (var child in config.GetChildren())
        {
            Environment.SetEnvironmentVariable(child.Key, child.Value?.Trim());
        }
    }
    
}