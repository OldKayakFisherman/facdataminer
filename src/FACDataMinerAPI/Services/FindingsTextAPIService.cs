namespace FACDataMinerAPI.Services;

public class FindingsTextAPIService: BaseAPIService
{
    public async Task<IList<IDictionary<string, string>>> GetNewRecords(IList<string> reportIds,
        int batchPullSize,
        StandardAPIServiceArguments args)
    {
        return await PerformBatchRequest("findings_text", batchPullSize, reportIds, args);
    }
}