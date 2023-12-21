namespace FACDataMinerAPI.Services;

public class FindingAPIService: BaseAPIService
{
    public async Task<IList<IDictionary<string, string>>> GetNewRecords(IList<string> reportIds,
        int batchPullSize,
        StandardAPIServiceArguments args)
    {
        return await PerformBatchRequest("findings", batchPullSize, reportIds, args);
    }
}