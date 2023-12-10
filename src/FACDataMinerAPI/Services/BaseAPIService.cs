using RestSharp;

namespace FACDataMinerAPI.Services;

public class BaseAPIService
{
    protected virtual async Task<FACAPIResponse<T>> PerformRequest<T>(string apiEndpoint, StandardAPIServiceArguments args)
    {
        Uri targetUri = new Uri(args.BaseEndpoint, apiEndpoint);
        
        var client = new RestClient(args.HttpClient);
        var request = new RestRequest(targetUri);

        request.AddHeader("X-Api-Key", args.Token);

        if (args.IsLimited)
        {
            request.AddParameter(args.CreateLimiterParameter());
        }
        
        var clientResponse = await client.ExecuteAsync(request);

        FACAPIResponse<T> facapiResponse =
            new FACAPIResponse<T>(clientResponse);

        return facapiResponse;
    }
}