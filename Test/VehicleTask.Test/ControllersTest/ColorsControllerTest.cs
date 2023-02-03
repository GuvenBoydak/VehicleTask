using System.Net;
using System.Net.Http.Json;
using Newtonsoft.Json;
using VehicleTask.Application.DTOs.Colors;
using VehicleTask.Application.Features.Command.Color.CreateColor;
using VehicleTask.Application.Features.Command.Color.UpdateColor;
using VehicleTask.Test.Dtos;
using VehicleTask.Test.FakeEntity;
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
    
    [Fact]
    public async Task should_success_get_by_ıd_color()
    {
        // act
        var client = _factory.HttpClientFactory();

        var response = await client.GetStringAsync($"/api/Colors/{FakeColor.BlackColor.Id}");

        var colorList = JsonConvert.DeserializeObject<CustomResponseDto<ColorDto>>(response);

        // assert
        Assert.Equal(200, colorList.StatusCode);
    }
    
    [Fact]
    public async Task should_success_add_update_and_delete_color()
    {
        //arrange|add
        var color = new CreateColorCommand()
        {
            Name = "Sarı"
        };

        // act|add
        var client = _factory.HttpClientFactory();
        var response = await client.PostAsJsonAsync("/api/Colors", color);
        var createdItem =
            JsonConvert.DeserializeObject<CustomResponseDto<ColorDto>>(response.Content.ReadAsStringAsync().Result);


        // assert|add
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.NotNull(createdItem.Data);

        //arrange|update
        var updateColor = new UpdateColorCommand()
        {
            Id = createdItem.Data.Id,
            Name = "Mavi"
        };

        // act|update
        response = await client.PutAsJsonAsync("/api/Colors", updateColor);
        var updatedItem =
            JsonConvert.DeserializeObject<CustomResponseDto<ColorDto>>(response.Content.ReadAsStringAsync().Result);

        // assert|updated
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.NotNull(updatedItem.Data);
        Assert.NotEqual(createdItem.Data.Name, updatedItem.Data.Name);
        
        
        // act|delete
        response = await client.DeleteAsync($"/api/Colors/{updatedItem.Data.Id}");

        // assert|updated
        Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
    }
}