namespace FACDataMinerAPI.Services;

public class CorrectiveActionPlanAPIService: BaseAPIService
{
    public async Task<IList<IDictionary<string, string>>> GetNewRecords(IList<string> reportIds,
        int batchPullSize,
        StandardAPIServiceArguments args)
    {
        return await PerformBatchRequest("corrective_action_plans", batchPullSize, reportIds, args);
    }
}