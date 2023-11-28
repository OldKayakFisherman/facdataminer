using FACDataMinerDAL;
using FACDataMinerDAL.Repositories;
using FACDataMinerDAL.Entities;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using NUnit;

namespace FACDataMinderDAL.Tests.Repository;

[TestFixture]
public class GeneralRepositoryTests
{
    [Test]
    public void TestGetUniqueReportsByAuditYear()
    {
        using var ctx = new InMemoryFACDbContext();

        GeneralRecordRepository repo = new GeneralRecordRepository(ctx.Context);
        
        repo.Add(new GeneralRecord("ABC-123", 2016, "A"));
        repo.Add(new GeneralRecord("DEF-345", 2017, "B"));
        repo.Add(new GeneralRecord("GHI-678", 2017, "C"));
        repo.Add(new GeneralRecord("JKL-912", 2018, "D"));
        repo.Add(new GeneralRecord("MNO-345", 2018, "E"));
        repo.Add(new GeneralRecord("PQR-678", 2018, "E"));
        
        Assert.That(repo.GetUniqueReportsByAuditYear(2016).Count, Is.EqualTo(1));
        Assert.That(repo.GetUniqueReportsByAuditYear(2017).Count, Is.EqualTo(2));
        Assert.That(repo.GetUniqueReportsByAuditYear(2018).Count, Is.EqualTo(3));
        
    }
}