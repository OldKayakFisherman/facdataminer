using RestSharp;

namespace FACDataMinerAPI;

public class StandardAPIServiceArguments
{
    public Uri BaseEndpoint { get; set; }
    public HttpClient HttpClient { get; set; }
    private int? RecordLimiter { get; set; }

    public string Token { get; set; }

    public StandardAPIServiceArguments(Uri baseEndpoint, string token ,HttpClient httpClient, int? recordLimiter = null)
    {
        this.BaseEndpoint = baseEndpoint;
        this.HttpClient = httpClient;
        this.RecordLimiter = recordLimiter;
        this.Token = token;
    }

    public bool IsLimited => RecordLimiter.HasValue;

    public QueryParameter CreateLimiterParameter()
    {
        return new QueryParameter("limit", RecordLimiter?.ToString());
    }
}