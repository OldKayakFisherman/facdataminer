using FACDataMinerDAL.Entities;

namespace FACDataMinerDAL.Repositories;

public class GeneralRecordRepository: BaseRepository<GeneralRecord>, IBaseRepository<GeneralRecord>
{
    private readonly FACDbContext _ctx;
    
    public GeneralRecordRepository(FACDbContext ctx): base(ctx)
    {
        _ctx = ctx;
    }
    
    
}