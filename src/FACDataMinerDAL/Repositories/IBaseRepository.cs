using FACDataMinerDAL.Entities;

namespace FACDataMinerDAL.Repositories;

public interface IBaseRepository<T> where T : class, IBaseFACRecord
{
    IList<T> All();
    void Add(T entity);
    void Delete(T entity);
    void BulkInsert(IList<T> entities);
    void BulkDelete(IList<T> entities);
    T? Find(int id);
    IList<T> FindByReportId(string reportId);
    IList<T> FindByAuditYear(short auditYear);
    IList<T> FindByAuditeeUEI(string auditeeUEI);

    
}