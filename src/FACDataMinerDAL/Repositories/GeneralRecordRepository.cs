using FACDataMinerDAL.Entities;

namespace FACDataMinerDAL.Repositories;

public class GeneralRecordRepository: BaseRepository<GeneralRecord>, IBaseRepository<GeneralRecord>
{
    private readonly FACDbContext _ctx;
    
    public GeneralRecordRepository(FACDbContext ctx): base(ctx)
    {
        _ctx = ctx;
    }

    public IList<string> GetUniqueReportsByAuditYear(short auditYear)
    {
        return _ctx.GeneralRecords
            .Where(x => x.AuditYear == auditYear)
            .Select(x => x.ReportId).ToList();
    }
    
}