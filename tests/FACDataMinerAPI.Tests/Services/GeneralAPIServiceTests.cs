using FACDataMinerAPI.Services;

namespace FACDataMinerAPI.Tests.Services;

[TestFixture]
public class GeneralAPIServiceTests
{
    [Test]
    public async Task TestGetReportIdsByAuditYear()
    {
        var service = new GeneralAPIService();
        
        FACAPIResponse<IList<IDictionary<string,string>>> response = await service.GetReportIdsByAuditYear(2023, 
            TestHelpers.CreateStandardApiTestApiServiceArguments(1));
        
        Assert.That(response, Is.Not.Null);

        if (!response.IsSuccessful)
        {
            if (!string.IsNullOrEmpty(response.ErrorMessage))
            {
                Console.WriteLine($"Error Message: {response.ErrorMessage}");
            }
        }
        
        Assert.Multiple(() =>
        {
            Assert.That(response.Exception, Is.Null);
            Assert.That(response.ErrorMessage, Is.Null);
            Assert.That(response.IsSuccessful, Is.True);
        });
        
        Assert.Multiple(() =>
        {
            Assert.That(response.ResultColumnCount, Is.EqualTo(1));
            Assert.That(response.Data, Is.Not.Null);
        });
    }

    [Test]
    public async Task TestGetNewAudits()
    {
        var service = new GeneralAPIService();

        StandardAPIServiceArguments args = TestHelpers.CreateStandardApiTestApiServiceArguments();
        
        IList<string> auditReportIds = new List<string>() { "2023-06-GSAFAC-0000000002", "2023-06-GSAFAC-0000000087" };

        IList<IDictionary<string, string>> results = await service.GetNewAudits(auditReportIds, 1, args);
        
        Assert.That(results.Count, Is.EqualTo(2));
        
    }
    
}