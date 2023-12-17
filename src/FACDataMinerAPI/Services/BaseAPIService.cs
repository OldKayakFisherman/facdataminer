using RestSharp;
using MoreLinq;
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

    protected virtual async Task<IList<IDictionary<string, string>>> PerformBatchRequest(string apiEndpoint, int batchPullSize,
        IList<string> reportIds, StandardAPIServiceArguments args)
    {
        IList<IDictionary<string, string>> result = new List<IDictionary<string, string>>();
        
        //We need to batch pull these in order to prevent excessive query string length
        var batches = reportIds.Batch(batchPullSize);

        Uri targetUri = new Uri(args.BaseEndpoint, apiEndpoint);

        IList<FACAPIResponse<IList<IDictionary<string, string>>>> batchedResponses = new List<FACAPIResponse<IList<IDictionary<string, string>>>>();
        
        foreach (var batch in batches)
        {
            var client = new RestClient(args.HttpClient);
            var request = new RestRequest(targetUri);

            request.AddHeader("X-Api-Key", args.Token);
            request.AddParameter(ToInQueryParameter(batch));
            
            if (args.IsLimited)
            {
                request.AddParameter(args.CreateLimiterParameter());
            }
            
            var clientResponse = await client.ExecuteAsync(request);

            batchedResponses.Add(new FACAPIResponse<IList<IDictionary<string, string>>>(clientResponse));
        }
        
        //Iterate over the responses and construct our result
        foreach (var batchResponse in batchedResponses)
        {
            if (batchResponse.IsSuccessful)
            {
                if (batchResponse.Data != null)
                {
                    result = result.Concat(batchResponse.Data).ToList();
                }
            }
        }

        return result;
    }

    protected QueryParameter ToInQueryParameter(IList<string> reports)
    { 
        return new QueryParameter("report_id", $"in.({string.Join(',', reports)})");
    }
}