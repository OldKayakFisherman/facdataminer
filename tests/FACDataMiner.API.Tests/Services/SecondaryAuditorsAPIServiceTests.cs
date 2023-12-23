using FACDataMinerAPI.Services;

namespace FACDataMinerAPI.Tests.Services;

[TestFixture]
public class SecondaryAuditorsAPIServiceTests
{
    [Test]
    public async Task TestGetNewRecords()
    {
        var service = new SecondaryAuditorsAPIService();

        StandardAPIServiceArguments args = TestHelpers.CreateStandardApiTestApiServiceArguments();
        
        IList<string> auditReportIds = new List<string>() { "2023-04-GSAFAC-0000000558", "2023-06-GSAFAC-0000000187" };

        IList<IDictionary<string, string>> results = await service.GetNewRecords(auditReportIds, 1, args);
        
        Assert.That(results.Count, Is.EqualTo(2));
        
    }

}