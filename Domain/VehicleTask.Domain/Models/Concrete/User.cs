using VehicleTask.Domain.Models.Abstract;

namespace VehicleTask.Domain.Models.Concrete;

public class User:IBaseEntity
{
    public User()
    {
        Id=Guid.NewGuid();
        CreatedDate = DateTime.UtcNow;
        IsDeleted = false;
    }

    public Guid Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime DeletedDate { get; set; }
    public bool IsDeleted { get; set; }
    
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public byte[] PasswordHash { get; set; }
    public byte[] PasswordSalt { get; set; }
}