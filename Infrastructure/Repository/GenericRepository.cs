using Context;
using Domain.Extensions;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class GenericRepository<T> : IGenericRepository<T> where T : class, IBaseDatabaseModel
{
    private readonly ClaimsDbContext Context;
    private readonly DbSet<T> DbSet;

    public GenericRepository(ClaimsDbContext context)
    {
        Context = context;
        DbSet = Context.Set<T>();
    }

    public async Task<T> Insert(T model)
    {
        await DbSet.AddAsync(model);
        await Context.SaveChangesWithConcurrencyHandlingAsync();
        return model;
    }

    public async Task<IQueryable<T>?> GetById(int id) => DbSet.Where(m => m.Id == id);

    public async Task<IQueryable<T>> Get() => DbSet.AsNoTracking();

    public async Task Update(T updatedModel)
    {
        DbSet.Update(updatedModel);
        await Context.SaveChangesWithConcurrencyHandlingAsync();
    }

    public async Task Delete(params int[] ids)
    {
        if (ids.IsNotNullOrEmpty())
        {
            await DbSet.Where(m => ids.Contains(m.Id)).ExecuteDeleteAsync();
            await Context.SaveChangesWithConcurrencyHandlingAsync();
        }
    }


}
