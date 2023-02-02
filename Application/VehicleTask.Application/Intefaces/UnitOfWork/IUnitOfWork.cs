namespace VehicleTask.Application.Intefaces.UnitOfWork;

public interface IUnitOfWork
{
    Task SaveChangesAsync();
}