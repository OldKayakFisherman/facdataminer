using FACDataMinerAPI.Services;

namespace FACDataMinerAPI.Tests.Services;

[TestFixture]
public class PassthroughAPIServiceTests
{
    [Test]
    public async Task TestGetNewRecords()
    {
        var service = new PassthroughAPIService();

        StandardAPIServiceArguments args = TestHelpers.CreateStandardApiTestApiServiceArguments();
        
        IList<string> auditReportIds = new List<string>() { "2023-01-GSAFAC-0000000854", "2023-06-GSAFAC-0000000688" };

        IList<IDictionary<string, string>> results = await service.GetNewRecords(auditReportIds, 1, args);
        
        Assert.That(results.Count, Is.EqualTo(2));
        
    }

}