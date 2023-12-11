using System.Collections;
using System.Net;
using System.Text.Json;
using RestSharp;

namespace FACDataMinerAPI;

public class FACAPIResponse<T>
{
    public T? Data { get; set; } 
    public bool IsSuccessful { get; set; } = false;
    public Uri? ResponseUri { get; set; }
    public IList<string> ApiResponseColumns { get; set; } = new List<string>();
    public HttpStatusCode? HttpStatusCode { get; set; }
    public int ResultColumnCount { get; set; } = 0;
    public Exception? Exception { get; set; }
    public string? ErrorMessage { get; set; }

    public FACAPIResponse(RestResponse response)
    {
        Initialize(response);
    }

    private void Initialize(RestResponse response)
    {
        this.IsSuccessful = response.IsSuccessful;
        this.ResponseUri = response.ResponseUri;
        
        Console.WriteLine($"Response: {response.ResponseUri}");
        
        if (response.IsSuccessful)
        {
            this.HttpStatusCode = response.StatusCode;
            CalculateColumns(response.Content);

            if (!string.IsNullOrEmpty(response.Content))
            {
                Data = JsonSerializer.Deserialize<T>(response.Content);
            }
        }
        else
        {
            if (response.ErrorException != null)
            {
                this.ErrorMessage = response.ErrorMessage;
                this.Exception = Exception;
            }
        }
    }

    private void CalculateColumns(string? content)
    {
        if (string.IsNullOrEmpty(content)) return;
        var evalValues = JsonSerializer.Deserialize<IList<IDictionary<string, string>>>(content);

        if (evalValues != null)
        {
            ResultColumnCount = evalValues[0].Keys.Count;
        }
    }
    
}