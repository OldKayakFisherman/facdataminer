using FACDataMinerDAL.Entities;
using Microsoft.EntityFrameworkCore;


namespace FACDataMinerDAL.Repositories;

public class GeneralRecordRepository: BaseRepository<GeneralRecord>, IBaseRepository<GeneralRecord>
{
    private readonly FACDbContext _ctx;
    
    public GeneralRecordRepository(FACDbContext ctx): base(ctx)
    {
        _ctx = ctx;
    }

    public async Task<List<string?>> GetUniqueReportsByAuditYear(int auditYear)
    {
        return await _ctx.GeneralRecords
            .Where(x => x.AuditYear == auditYear)
            .Select(x => x.ReportId).ToListAsync();
    }
    
    
    
}