namespace FACDataMinerAPI.Services;

public class AdditionalUEIsAPIService: BaseAPIService
{
    public async Task<IList<IDictionary<string, string>>> GetNewRecords(IList<string> reportIds,
        int batchPullSize,
        StandardAPIServiceArguments args)
    {
        return await PerformBatchRequest("additional_ueis", batchPullSize, reportIds, args);
    }
}