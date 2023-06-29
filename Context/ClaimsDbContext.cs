using Domain.Models;
using Domain.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Context;

public class ClaimsDbContext : DbContext, IDbContext
{
    public ClaimsDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Seed();
        modelBuilder.Entity<Insured>()
            .HasIndex(x => x.CardNumber)
            .IsUnique();
        base.OnModelCreating(modelBuilder);
    }

    public async Task<int> SaveChangesWithConcurrencyHandlingAsync()
    {
        try
        {
            return await SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException ex)
        {
            foreach (var entry in ex.Entries)
            {
                if (entry.State == EntityState.Deleted)
                {
                    throw; // TODO: LOG
                }
                else
                {
                    entry.OriginalValues.SetValues(await entry.GetDatabaseValuesAsync());
                }
            }
            throw;
        }
    }

    public DbSet<Insured> Insured{ get; set; }

    public DbSet<Claim> Claims{ get; set; }
}

internal interface IDbContext
{
    Task<int> SaveChangesWithConcurrencyHandlingAsync();
}
