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
    
    public virtual IList<T> All()
    {
        return _ctx.Set<T>().ToList();
    }
    
    public virtual void Add(T entity)
    {
        _ctx.Set<T>().Add(entity);
        _ctx.SaveChanges();
    }
    
    public virtual void Delete(T entity)
    {
        _ctx.Set<T>().Remove(entity);
        _ctx.SaveChanges();
    }

    public virtual void BulkInsert(IList<T> entities)
    {
        _ctx.BulkInsert(entities);
        _ctx.BulkSaveChanges();
    }

    public virtual void BulkDelete(IList<T> entities)
    {
        _ctx.BulkDelete(entities);
        _ctx.BulkSaveChanges();
    }

    public T? Find(int id)
    {
        return _ctx.Find<T>(id);
    }

    public IList<T> FindByReportId(string reportId)
    {
        return _ctx.Set<T>().Where(x => x.ReportId == reportId).ToList();
    }

    public IList<T> FindByAuditYear(short auditYear)
    {
        return _ctx.Set<T>().Where(x => x.AuditYear == auditYear).ToList();
    }

    public IList<T> FindByAuditeeUEI(string auditeeUEI)
    {
        return _ctx.Set<T>().Where(x => x.AuditeeUEI == auditeeUEI).ToList();
    }
    
}