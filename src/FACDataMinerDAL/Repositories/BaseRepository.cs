using System.Xml.Linq;
using FACDataMinerDAL.Entities;
using Microsoft.EntityFrameworkCore;
using EFCore.BulkExtensions;

namespace FACDataMinerDAL.Repositories;

public class BaseRepository<T> where T : class
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

}