namespace FACDataMinerAPI.Services;

public class NotesToSefaAPIService: BaseAPIService
{
    public async Task<IList<IDictionary<string, string>>> GetNewRecords(IList<string> reportIds,
        int batchPullSize,
        StandardAPIServiceArguments args)
    {
        return await PerformBatchRequest("notes_to_sefa", batchPullSize, reportIds, args);
    }
}