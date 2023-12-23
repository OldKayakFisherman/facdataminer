using FACDataMinerAPI.Services;

namespace FACDataMinerAPI.Tests.Services;

[TestFixture]
public class NotesToSefaAPIServiceTests
{
    [Test]
    public async Task TestGetNewRecords()
    {
        var service = new NotesToSefaAPIService();

        StandardAPIServiceArguments args = TestHelpers.CreateStandardApiTestApiServiceArguments();
        
        IList<string> auditReportIds = new List<string>() { "2023-01-GSAFAC-0000000854" };

        IList<IDictionary<string, string>> results = await service.GetNewRecords(auditReportIds, 1, args);
        
        Assert.That(results.Count, Is.EqualTo(3));
        
    }

}