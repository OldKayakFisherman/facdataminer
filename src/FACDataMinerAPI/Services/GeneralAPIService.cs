using System.Text.Json;
using RestSharp;


namespace FACDataMinerAPI.Services;

public class GeneralAPIService
{
    public IList<string> GetReportIdsByAuditYear(int auditYear, Uri baseEndpoint,string token, HttpClient httpClient)
    {
        Uri targetUri = new Uri(baseEndpoint, $"general?select=report_id&audit_year=eq.{auditYear}");

        var client = new RestClient(httpClient);
        var request = new RestRequest(targetUri, Method.Get);

        request.AddHeader("X-Api-Key", token);

        var response = client.Execute(request);

        return JsonSerializer.Deserialize<IList<string>>(response.Content);

    }
}