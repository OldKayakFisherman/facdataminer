using FACDataMinerDAL;
using FACDataMinerDAL.Repositories;
using FACDataMinerDAL.Entities;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using NUnit;
using NUnit.Framework.Constraints;

namespace FACDataMinderDAL.Tests.Repository;

[TestFixture]
public class GeneralRepositoryTests
{
    [Test]
    public async Task TestGetUniqueReportsByAuditYear()
    {
        using var ctx = new InMemoryFACDbContext();

        GeneralRecordRepository repo = new GeneralRecordRepository(ctx.Context);
        
       
        for (int y = 2016; y <= 2023; y++)
        {
            var rdm = new Random();

            int sampleSize = rdm.Next(1, 30);

            IList<GeneralRecord> sampleRecords = TestDataHelper.ConstructGeneralRecordsWithAuditYear(y, sampleSize);
            
            repo.BulkInsert(sampleRecords);
            
            Assert.That(await repo.GetUniqueReportsByAuditYear(y), Has.Count.EqualTo(sampleSize));
            
        }
            
        
    }
}