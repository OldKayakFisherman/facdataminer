using System.Collections;
using System.Text.Json;
using RestSharp;


namespace FACDataMinerAPI.Services;

public class GeneralAPIService: BaseAPIService
{
    public async Task<FACAPIResponse<IList<IDictionary<string, string>>>> GetReportIdsByAuditYear(int auditYear, StandardAPIServiceArguments args)
    {
        string apiEndpoint = $"general?select=report_id&audit_year=eq.{auditYear}";
        return await base.PerformRequest<IList<IDictionary<string, string>>>(apiEndpoint, args);
    }
}