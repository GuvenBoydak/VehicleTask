namespace VehicleTask.Domain.Models.Abstract;

public interface IBaseEntity
{
    public Guid Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime DeletedDate { get; set; }
    public bool IsDeleted { get; set; }
}