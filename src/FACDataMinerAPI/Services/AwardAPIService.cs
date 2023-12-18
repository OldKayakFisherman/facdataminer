namespace FACDataMinerAPI.Services;

public class AwardAPIService: BaseAPIService
{
    public async Task<IList<IDictionary<string, string>>> GetNewRecords(IList<string> reportIds,
        int batchPullSize,
        StandardAPIServiceArguments args)
    {
        return await PerformBatchRequest("federal_awards", batchPullSize, reportIds, args);
    }
}