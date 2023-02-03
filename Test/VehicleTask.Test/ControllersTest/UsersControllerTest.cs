using System.Net;
using System.Net.Http.Json;
using Newtonsoft.Json;
using VehicleTask.Application.DTOs.Users;
using VehicleTask.Application.Features.Command.Users.RegisterUser;
using VehicleTask.Test.Dtos;
using VehicleTask.Test.FakeEntity;
using VehicleTask.Test.TestSetup;

namespace VehicleTask.Test.ControllersTest;

public class UsersControllerTest : IClassFixture<InMemoryWebApplicationFactory<Program>>
{
    private InMemoryWebApplicationFactory<Program> _factory;

    public UsersControllerTest(InMemoryWebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task should_success_get_user_list()
    {
        // act
        var client = _factory.HttpClientFactory();

        var response = await client.GetStringAsync("/api/Users/getAll");

        var userList = JsonConvert.DeserializeObject<CustomResponseDto<List<UserListDto>>>(response);

        // assert
        Assert.Equal(200, userList.StatusCode);
        Assert.Single(userList.Data);
    }

    [Fact]
    public async Task should_success_register_user()
    {
        //arrange
        var user = new RegisterUserCommand()
        {
            FirstName = "Lorem",
            LastName = "Ipsun",
            Email = "Lorem@lorem.com",
            Password = "123456"
        };
        // act
        var client = _factory.HttpClientFactory();

        var response = await client.PostAsJsonAsync("/api/Users/register", user);

        // assert
        Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
    }

    [Fact]
    public async Task should_success_login_user()
    {
        //arrange
        var user = new RegisterUserCommand()
        {
            Email = FakeUser.Test.Email,
            Password = "123456"
        };
        // act
        var client = _factory.HttpClientFactory();

        var response = await client.PostAsJsonAsync("/api/Users/login", user);

        var token =
            JsonConvert.DeserializeObject<CustomResponseDto<TokenDto>>(await response.Content.ReadAsStringAsync());

        // assert
        Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        Assert.NotNull(token.Data);
    }
}