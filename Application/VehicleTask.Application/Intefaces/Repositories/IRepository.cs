using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using VehicleTask.Domain.Models.Abstract;

namespace VehicleTask.Application.Intefaces.Repositories;

public interface IRepository<T> where T : Vehicle
{
    DbSet<T> Table { get; }

    Task<T> GetById(Guid id);

    IQueryable<T> Where(Expression<Func<T, bool>> filter);

    Task<List<T>> GetAllAsync();

    Task AddAsync(T entity);

    Task DeleteAsync(Guid id);

    void Update(T entity);
}