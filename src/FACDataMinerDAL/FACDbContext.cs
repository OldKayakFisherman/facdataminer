using Microsoft.EntityFrameworkCore;
using Npgsql;
using Microsoft.Extensions.Configuration;
using FACDataMinerDAL.Entities;

namespace FACDataMinerDAL;


public class FACDbContext: DbContext
{
    private readonly IConfiguration Configuration;
    
    public FACDbContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseNpgsql(Configuration.GetConnectionString("FACDB"));
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