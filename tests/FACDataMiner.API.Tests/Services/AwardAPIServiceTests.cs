using FACDataMinerAPI.Services;

namespace FACDataMinerAPI.Tests.Services;

[TestFixture]
public class AwardAPIServiceTests
{
    [Test]
    public async Task TestGetNewRecords()
    {
        var service = new AwardAPIService();

        StandardAPIServiceArguments args = TestHelpers.CreateStandardApiTestApiServiceArguments();
        
        IList<string> auditReportIds = new List<string>() { "2023-01-GSAFAC-0000000854"};

        IList<IDictionary<string, string>> results = await service.GetNewRecords(auditReportIds, 1, args);
        
        Assert.That(results.Count, Is.EqualTo(7));
        
    }

}