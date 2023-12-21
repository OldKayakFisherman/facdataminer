namespace FACDataMinerAPI.Services;

public class SecondaryAuditorsAPIService: BaseAPIService
{
    public async Task<IList<IDictionary<string, string>>> GetNewRecords(IList<string> reportIds,
        int batchPullSize,
        StandardAPIServiceArguments args)
    {
        return await PerformBatchRequest("general", batchPullSize, reportIds, args);
    }    
}