

using DotNetEnv;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace FACDataMinerAPI.Tests;

public class TestHelpers
{
    private static readonly HttpClient _httpClient;
    private static readonly string? _api_key;
    private static readonly string? _api_endpoint;
    
    static TestHelpers()
    {
        _httpClient = new HttpClient();
        
        /*
        var config = new ConfigurationBuilder()
            .AddUserSecrets<TestHelpers>()
            .Build();
        */
        
        SetEnvironmentVariablesFromUserSecrets();
        
        _api_key = Environment.GetEnvironmentVariable("API_TOKEN");
        _api_endpoint = Environment.GetEnvironmentVariable("API_ENDPOINT");

    }
    
    public static string GetAPIKey()
    {
        return _api_key;
    }
    
    public static Uri GetAPIEndpoint()
    {
        return new Uri(_api_endpoint);
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
    
    
    static void SetEnvironmentVariablesFromUserSecrets()
    {
        var config = new ConfigurationBuilder().AddUserSecrets<TestHelpers>().Build();
        foreach (var child in config.GetChildren())
        {
            Environment.SetEnvironmentVariable(child.Key, child.Value);
        }
    }
    
}