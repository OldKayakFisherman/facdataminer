using FACDataMinerAPI.Services;

namespace FACDataMinerAPI.Tests.Services;

[TestFixture]
public class AdditionalUEIsAPIServiceTests
{
    [Test]
    public async Task TestGetNewRecords()
    {
        var service = new AdditionalUEIsAPIService();

        StandardAPIServiceArguments args = TestHelpers.CreateStandardApiTestApiServiceArguments();
        
        IList<string> auditReportIds = new List<string>() { "2023-04-GSAFAC-0000000495", "2023-03-GSAFAC-0000000321" };

        IList<IDictionary<string, string>> results = await service.GetNewRecords(auditReportIds, 1, args);
        
        Assert.That(results.Count, Is.EqualTo(2));
        
    }

}