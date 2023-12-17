using System.Xml.Linq;
using FACDataMinerDAL.Entities;
using Microsoft.EntityFrameworkCore;
using EFCore.BulkExtensions;

namespace FACDataMinerDAL.Repositories;

public class BaseRepository<T> where T : class, IBaseFACRecord
{
    
    private readonly FACDbContext _ctx;
    
    protected BaseRepository(FACDbContext ctx)
    {
        _ctx = ctx;
    }
    
    public virtual async Task<IList<T>> All()
    {
        return await _ctx.Set<T>().ToListAsync();
    }
    
    public virtual async Task Add(T entity)
    {
        await _ctx.Set<T>().AddAsync(entity);
        await _ctx.SaveChangesAsync();
    }
    
    public virtual async Task Delete(T entity)
    {
        _ctx.Set<T>().Remove(entity);
        await _ctx.SaveChangesAsync();
    }

    public virtual async Task BulkInsert(IList<T> entities)
    {
        await _ctx.BulkInsertAsync(entities);
        await _ctx.BulkSaveChangesAsync();
    }

    public virtual async Task BulkDelete(IList<T> entities)
    {
        await _ctx.BulkDeleteAsync(entities);
        await _ctx.BulkSaveChangesAsync();
    }

    public virtual async Task<T?> Find(int id)
    {
        return await _ctx.FindAsync<T>(id);
    }

    public virtual async Task<IList<T>> FindByReportId(string reportId)
    {
        return await _ctx.Set<T>().Where(x => x.ReportId == reportId).ToListAsync();
    }

    public virtual async Task<IList<T>> FindByAuditYear(short auditYear)
    {
        return await _ctx.Set<T>().Where(x => x.AuditYear == auditYear).ToListAsync();
    }

    public virtual async Task<IList<T>> FindByAuditeeUEI(string auditeeUEI)
    {
        return await _ctx.Set<T>().Where(x => x.AuditeeUEI == auditeeUEI).ToListAsync();
    }
    
}