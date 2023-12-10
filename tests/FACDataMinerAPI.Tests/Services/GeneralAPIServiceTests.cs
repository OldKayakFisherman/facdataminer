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
            Console.WriteLine(response.ResponseUri.ToString());

            if (!string.IsNullOrEmpty(response.ErrorMessage))
            {
                Console.WriteLine(response.ErrorMessage);
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
}