using System.Net.Http.Headers;
using System.Net.Http.Json;
using Newtonsoft.Json;
using VehicleTask.Test.Dtos;

namespace VehicleTask.Test.TestSetup;

public static class InMemoryWebApplicationFactoryExtension
{
    public static HttpClient HttpClientFactory(this InMemoryWebApplicationFactory<Program> factory)
    {
        var client = factory.CreateClient();

        var loginUserDto = new LoginUserDto() { Email = "test@test.com", Password = "123456" };

        var response = client.PostAsJsonAsync("api/Users/login", loginUserDto).GetAwaiter().GetResult();

        var token = JsonConvert.DeserializeObject<CustomResponseDto<TokenDto>>(response.Content.ReadAsStringAsync()
            .Result);

        client.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", $"{token.Data.AccessToken}");

        return client;
    }
}