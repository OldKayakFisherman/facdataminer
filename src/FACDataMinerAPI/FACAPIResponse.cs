using System.Collections;
using System.Net;
using RestSharp;
using Newtonsoft.Json;

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
        
        if (response.IsSuccessful)
        {
            this.HttpStatusCode = response.StatusCode;
            CalculateColumns(response.Content);

            if (!string.IsNullOrEmpty(response.Content))
            {
                Data = JsonConvert.DeserializeObject<T>(response.Content);

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
        
        var evalValues = JsonConvert.DeserializeObject<T>(content);

        if (evalValues != null && evalValues.GetType() == typeof(List<IDictionary<string, string>>))
        {
            ResultColumnCount = ((IList<IDictionary<string, string>>)evalValues)[0].Keys.Count;
        }
      
    }
    
}