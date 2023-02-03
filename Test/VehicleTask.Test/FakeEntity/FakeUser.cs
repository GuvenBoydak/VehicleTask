using VehicleTask.Application.Helper;
using VehicleTask.Domain.Models.Concrete;

namespace VehicleTask.Test.FakeEntity;

public static class FakeUser
{
    public static readonly User Test;

    static FakeUser()
    {
        Test = Add();
    }

    private static User Add()
    {
        byte[] passwordHash, passwordSalt;
        HashingHelper.CreatePasswordHash("123456", out passwordHash, out passwordSalt);

        return new User()
        {
            Id = Guid.NewGuid(), CreatedDate = DateTime.UtcNow, FirstName = "Test", LastName = "Test",
            Email = "test@test.com", PasswordHash = passwordHash, PasswordSalt = passwordSalt
        };
    }
}