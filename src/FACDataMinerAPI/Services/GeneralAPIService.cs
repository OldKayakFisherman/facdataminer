using System.Buffers;
using System.Collections;
using System.Text.Json;
using RestSharp;
using MoreLinq;



namespace FACDataMinerAPI.Services;

public class GeneralAPIService: BaseAPIService
{
    public async Task<FACAPIResponse<IList<IDictionary<string, string>>>> GetReportIdsByAuditYear(int auditYear, StandardAPIServiceArguments args)
    {
        string apiEndpoint = $"general?select=report_id&audit_year=eq.{auditYear}";
        return await base.PerformRequest<IList<IDictionary<string, string>>>(apiEndpoint, args);
    }
    
    public async Task<IList<IDictionary<string, string>>> GetNewAudits(IList<string> reportIds,
        int batchPullSize,
        StandardAPIServiceArguments args)
    {
        return await PerformBatchRequest("general", batchPullSize, reportIds, args);
    }
    
}