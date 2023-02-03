using System.Net;
using System.Net.Http.Json;
using Newtonsoft.Json;
using VehicleTask.Application.DTOs.Buses;
using VehicleTask.Application.Features.Command.Buses.CreateBus;
using VehicleTask.Application.Features.Command.Buses.HeadlightsOnOrOffByBusId;
using VehicleTask.Application.Features.Command.Buses.UpdateBus;
using VehicleTask.Test.Dtos;
using VehicleTask.Test.FakeEntity;
using VehicleTask.Test.TestSetup;

namespace VehicleTask.Test.ControllersTest;

public class BusesControllerTest : IClassFixture<InMemoryWebApplicationFactory<Program>>
{
    private InMemoryWebApplicationFactory<Program> _factory;

    public BusesControllerTest(InMemoryWebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task should_success_get_bus_list()
    {
        // act
        var client = _factory.HttpClientFactory();

        var response = await client.GetStringAsync("/api/Buses/getAll");

        var busList = JsonConvert.DeserializeObject<CustomResponseDto<List<BusListDto>>>(response);

        // assert
        Assert.Equal(200, busList.StatusCode);
        Assert.Equal(2, busList.Data.Count);
    }

    [Fact]
    public async Task should_success_headlights_on_or_off_by_bus_id()
    {
        //arrange
        var bus = new HeadlightsOnOrOffByBusIdCommand()
        {
            Id = FakeBus.FordBus.Id,
            IsHeadlightOn = true
        };

        // act
        var client = _factory.HttpClientFactory();

        var response = await client.PostAsJsonAsync("/api/Buses/Headlights-On-Or-Off-ByBusId", bus);

        var busDto =
            JsonConvert.DeserializeObject<CustomResponseDto<BusDto>>(response.Content.ReadAsStringAsync().Result);

        // assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.NotEqual(FakeBus.FordBus.IsHeadlightOn, busDto.Data.IsHeadlightOn);
    }

    [Fact]
    public async Task should_success_add_update_and_delete_bus()
    {
        //arrange|add
        var bus = new CreateBusCommand()
        {
            Brand = "BMC",
            Wheel = 6,
            SeatCapacity = 3,
            IsHeadlightOn = false,
            ColorId = FakeColor.WhiteColor.Id
        };

        // act|add
        var client = _factory.HttpClientFactory();
        var response = await client.PostAsJsonAsync("/api/Buses", bus);
        var createdItem =
            JsonConvert.DeserializeObject<CustomResponseDto<BusDto>>(response.Content.ReadAsStringAsync().Result);


        // assert|add
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.NotNull(createdItem.Data);

        //arrange|update
        var updateBus = new UpdateBusCommand()
        {
            Id = createdItem.Data.Id,
            Brand = "Skoda",
            Wheel = 8,
            SeatCapacity = 3,
            IsHeadlightOn = true,
            ColorId = FakeColor.WhiteColor.Id
        };

        // act|update
        response = await client.PutAsJsonAsync("/api/Buses", updateBus);
        var updatedItem =
            JsonConvert.DeserializeObject<CustomResponseDto<BusDto>>(response.Content.ReadAsStringAsync().Result);

        // assert|updated
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.NotNull(updatedItem.Data);
        Assert.NotEqual(createdItem.Data.Brand, updatedItem.Data.Brand);
        Assert.NotEqual(createdItem.Data.IsHeadlightOn, updatedItem.Data.IsHeadlightOn);
        Assert.NotEqual(createdItem.Data.Wheel, updatedItem.Data.Wheel);


        // act|delete
        response = await client.DeleteAsync($"/api/Buses/{updatedItem.Data.Id}");

        // assert|updated
        Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
    }
}