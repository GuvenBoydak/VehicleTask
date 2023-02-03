using System.Net;
using System.Net.Http.Json;
using Newtonsoft.Json;
using VehicleTask.Application.DTOs.Boats;
using VehicleTask.Application.DTOs.Buses;
using VehicleTask.Application.Features.Command.Boats.CreateBoat;
using VehicleTask.Application.Features.Command.Boats.HeadlightsOnOrOffByBoatId;
using VehicleTask.Application.Features.Command.Boats.UpdateBoat;
using VehicleTask.Test.Dtos;
using VehicleTask.Test.FakeEntity;
using VehicleTask.Test.TestSetup;

namespace VehicleTask.Test.ControllersTest;

public class BoatsControllerTest : IClassFixture<InMemoryWebApplicationFactory<Program>>
{
    private InMemoryWebApplicationFactory<Program> _factory;

    public BoatsControllerTest(InMemoryWebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task should_success_get_boat_list()
    {
        // act
        var client = _factory.HttpClientFactory();

        var response = await client.GetStringAsync("/api/Boats/getAll");

        var boatList = JsonConvert.DeserializeObject<CustomResponseDto<List<BoatListDto>>>(response);

        // assert
        Assert.Equal(200, boatList.StatusCode);
        Assert.Equal(2, boatList.Data.Count);
    }

    [Fact]
    public async Task should_success_headlights_on_or_off_by_boat_id()
    {
        //arrange
        var boat = new HeadlightsOnOrOffByBoatIdCommand()
        {
            Id = FakeBoat.BeneteauBoat.Id,
            IsHeadlightOn = true
        };

        // act
        var client = _factory.HttpClientFactory();

        var response = await client.PostAsJsonAsync("/api/Boats/Headlights-On-Or-Off-ByBoatId", boat);

        var boatDto =
            JsonConvert.DeserializeObject<CustomResponseDto<BusDto>>(response.Content.ReadAsStringAsync().Result);

        // assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.NotEqual(FakeBoat.BeneteauBoat.IsHeadlightOn, boatDto.Data.IsHeadlightOn);
    }

    [Fact]
    public async Task should_success_add_update_and_delete_boat()
    {
        //arrange|add
        var boat = new CreateBoatCommand()
        {
            Brand = "Test",
            SeatCapacity = 3,
            IsHeadlightOn = false,
            ColorId = FakeColor.WhiteColor.Id
        };

        // act|add
        var client = _factory.HttpClientFactory();
        var response = await client.PostAsJsonAsync("/api/Boats", boat);
        var createdItem =
            JsonConvert.DeserializeObject<CustomResponseDto<BoatDto>>(response.Content.ReadAsStringAsync().Result);


        // assert|add
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.NotNull(createdItem.Data);

        //arrange|update
        var updateBoat = new UpdateBoatCommand()
        {
            Id = createdItem.Data.Id,
            Brand = "lorem ıpsun",
            SeatCapacity = 5,
            IsHeadlightOn = true,
            ColorId = FakeColor.BlackColor.Id
        };

        // act|update
        response = await client.PutAsJsonAsync("/api/Boats", updateBoat);
        var updatedItem =
            JsonConvert.DeserializeObject<CustomResponseDto<BoatDto>>(response.Content.ReadAsStringAsync().Result);

        // assert|updated
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.NotNull(updatedItem.Data);
        Assert.NotEqual(createdItem.Data.Brand, updatedItem.Data.Brand);
        Assert.NotEqual(createdItem.Data.IsHeadlightOn, updatedItem.Data.IsHeadlightOn);
        Assert.NotEqual(createdItem.Data.ColorId, updatedItem.Data.ColorId);
        Assert.NotEqual(createdItem.Data.SeatCapacity, updatedItem.Data.SeatCapacity);


        // act|delete
        response = await client.DeleteAsync($"/api/Boats/{updatedItem.Data.Id}");

        // assert|updated
        Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
    }
}