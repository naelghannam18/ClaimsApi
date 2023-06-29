using Context;
using Domain.Models;
using Microsoft.Extensions.Caching.Memory;

namespace Infrastructure.Repository;

public class CachedGenericRepository<T> : IGenericRepository<T> where T : class, IBaseDatabaseModel
{
    private readonly GenericRepository<T> Decorated;
    private readonly IMemoryCache Cache;
    private readonly string Prefix = $"{typeof(T).Name}-";

    public CachedGenericRepository(GenericRepository<T> decorated, IMemoryCache cache)
    {
        Decorated = decorated;
        Cache = cache;
    }

    public async Task Delete(params int[] ids)
    {
        if(ids?.Length > 0)
        {
            await Decorated.Delete(ids);

            for(int i = 0; i < ids.Length; i++)
            {
                var key = Prefix + ids[i];
                Cache.Remove(key);
            }
        }
    }

    public async Task<IQueryable<T>> Get() => await Decorated.Get();

    public async Task<IQueryable<T>?> GetById(int id) =>
        await Cache.GetOrCreateAsync
        (
          key: Prefix + id,
          async entry =>
          {
              entry.SetAbsoluteExpiration(TimeSpan.FromMinutes(5));
              return await Decorated.GetById(id);
          }
         );

    public async Task<T> Insert(T model)
    {
        await Decorated.Insert(model);
        Cache.Set(Prefix + model.Id, model);
        return model;
    }

    public async Task Update(T updatedModel)
    {
        await Decorated.Update(updatedModel);
        Cache.Remove(Prefix + updatedModel.Id);
    }
}
