namespace FACDataMinerAPI.Services;

public class PassthroughAPIService: BaseAPIService
{
    public async Task<IList<IDictionary<string, string>>> GetNewRecords(IList<string> reportIds,
        int batchPullSize,
        StandardAPIServiceArguments args)
    {
        return await PerformBatchRequest("passthrough", batchPullSize, reportIds, args);
    }
}