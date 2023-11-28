using FACDataMinerDAL.Entities;

namespace FACDataMinerDAL.Repositories;

public interface IBaseRepository<T> where T : class
{
    IList<T> All();
    void Add(T entity);
    void Delete(T entity);
    void BulkInsert(IList<T> entities);
    void BulkDelete(IList<T> entities);
}