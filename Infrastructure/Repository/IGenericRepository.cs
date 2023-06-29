using Domain.Models;

namespace Infrastructure.Repository
{
    public interface IGenericRepository<T> where T : class, IBaseDatabaseModel
    {
        Task Delete(params int[] ids);
        Task<IQueryable<T>> Get();
        Task<IQueryable<T>?> GetById(int id);
        Task<T> Insert(T model);
        Task Update(T updatedModel);
    }
}