using Newtonsoft.Json;
using VehicleTask.Application.DTOs.Colors;
using VehicleTask.Test.Dtos;
using VehicleTask.Test.TestSetup;

namespace VehicleTask.Test.ControllersTest;

public class ColorsControllerTest : IClassFixture<InMemoryWebApplicationFactory<Program>>
{
    private InMemoryWebApplicationFactory<Program> _factory;

    public ColorsControllerTest(InMemoryWebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task should_success_get_color_list()
    {
        // act
        var client = _factory.HttpClientFactory();

        var response = await client.GetStringAsync("/api/Colors/getAll");

        var colorList = JsonConvert.DeserializeObject<CustomResponseDto<List<ColorListDto>>>(response);

        // assert
        Assert.Equal(200, colorList.StatusCode);
        Assert.Equal(2, colorList.Data.Count);
    }
}