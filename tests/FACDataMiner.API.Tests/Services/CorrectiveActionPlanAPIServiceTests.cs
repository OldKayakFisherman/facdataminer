using FACDataMinerAPI.Services;

namespace FACDataMinerAPI.Tests.Services;

[TestFixture]
public class CorrectiveActionPlanAPIServiceTests
{
    [Test]
    public async Task TestGetNewRecords()
    {
        var service = new CorrectiveActionPlanAPIService();

        StandardAPIServiceArguments args = TestHelpers.CreateStandardApiTestApiServiceArguments();
        
        IList<string> auditReportIds = new List<string>() { "2023-03-GSAFAC-0000000812", "2022-12-GSAFAC-0000000112" };

        IList<IDictionary<string, string>> results = await service.GetNewRecords(auditReportIds, 1, args);
        
        Assert.That(results.Count, Is.EqualTo(2));
        
    }

}