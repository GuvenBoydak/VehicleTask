using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using VehicleTask.Application.Intefaces.Repositories;
using VehicleTask.Domain.Models.Abstract;
using VehicleTask.Infrastructure.Context;

namespace VehicleTask.Infrastructure.Repositories;

public class GenericRepository<T> : IRepository<T> where T : class, IBaseEntity
{
    private readonly VehicleDbContext _dbContext;

    public GenericRepository(VehicleDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public DbSet<T> Table => _dbContext.Set<T>();


    public async Task<T> GetById(Guid id)
    {
        return await Table.FirstOrDefaultAsync(x => x.Id == id);
    }

    public IQueryable<T> Where(Expression<Func<T, bool>> filter)
    {
        return Table.Where(filter);
    }

    public async Task<List<T>> GetAllAsync()
    {
        return await Table.ToListAsync();
    }

    public async Task AddAsync(T entity)
    {
        await Table.AddAsync(entity);
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity = await Table.FindAsync(id);
        if (entity == null)
            throw new InvalidOperationException($"{nameof(entity)} Not found");

        entity.IsDeleted = true;
        entity.DeletedDate = DateTime.UtcNow;
        Update(entity);
    }

    public void Update(T entity)
    {
        var currentEntity = Table.AsNoTracking().FirstOrDefault(x => x.Id == entity.Id);
        if (currentEntity == null)
            throw new InvalidOperationException($"{nameof(currentEntity)} Not found");

        Table.Entry(currentEntity).CurrentValues.SetValues(entity);

        foreach (var property in Table.Entry(entity).Properties)
        {
            if (property.CurrentValue != null && property.CurrentValue is not Guid)
                Table.Entry(entity).Property(property.Metadata.Name).IsModified = true;
        }
    }
}