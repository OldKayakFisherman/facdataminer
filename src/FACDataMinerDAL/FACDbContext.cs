using Microsoft.EntityFrameworkCore;
using FACDataMinerDAL.Entities;

namespace FACDataMinerDAL;


public class FACDbContext: DbContext
{
    public FACDbContext(DbContextOptions<FACDbContext> options): base(options)
    {
        
    } 
   

    public DbSet<AdditionalUEIRecord> AdditionalUEIRecords { get; set; }
    public DbSet<AwardRecord> AwardRecords { get; set; }
    public DbSet<CorrectiveActionPlanRecord> CorrectiveActionPlanRecords { get; set; }
    public DbSet<FindingRecord> FindingRecords { get; set; }
    public DbSet<FindingTextRecord> FindingTextRecords { get; set; }
    public DbSet<GeneralRecord> GeneralRecords { get; set; }
    public DbSet<NotesToSEFARecord> NotesToSEFARecords { get; set; }
    public DbSet<PassthroughRecord> PassthroughRecords { get; set; }
    public DbSet<SecondaryAuditorRecord> SecondaryAuditorRecords { get; set; }



}