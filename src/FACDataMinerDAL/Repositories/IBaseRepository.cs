using FACDataMinerDAL.Entities;

namespace FACDataMinerDAL.Repositories;

public interface IBaseRepository<T> where T : class, IBaseFACRecord
{
    Task<IList<T>> All();
    Task Add(T entity);
    Task Delete(T entity);
    Task BulkInsert(IList<T> entities);
    Task BulkDelete(IList<T> entities);
    Task<T?> Find(int id);
    Task<IList<T>> FindByReportId(string reportId);
    Task<IList<T>> FindByAuditYear(short auditYear);
    Task<IList<T>> FindByAuditeeUEI(string auditeeUEI);

    
}