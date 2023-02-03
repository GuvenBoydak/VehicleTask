using System.Net;
using System.Net.Http.Json;
using Newtonsoft.Json;
using VehicleTask.Application.DTOs.Cars;
using VehicleTask.Application.Features.Command.Car.CreateCar;
using VehicleTask.Application.Features.Command.Car.HeadlightsOnOrOffByCarId;
using VehicleTask.Application.Features.Command.Car.UpdateCar;
using VehicleTask.Test.Dtos;
using VehicleTask.Test.FakeEntity;
using VehicleTask.Test.TestSetup;

namespace VehicleTask.Test.ControllersTest;

public class CarsControllerTest : IClassFixture<InMemoryWebApplicationFactory<Program>>
{
    private InMemoryWebApplicationFactory<Program> _factory;

    public CarsControllerTest(InMemoryWebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task should_success_get_car_list()
    {
        // act
        var client = _factory.HttpClientFactory();

        var response = await client.GetStringAsync("/api/Cars/getAll");

        var carList = JsonConvert.DeserializeObject<CustomResponseDto<List<CarListDto>>>(response);

        // assert
        Assert.Equal(200, carList.StatusCode);
        Assert.Equal(2, carList.Data.Count);
    }

    [Fact]
    public async Task should_success_headlights_on_or_off_by__id()
    {
        //arrange
        var car = new HeadlightsOnOrOffByCarIdCommand()
        {
            Id = FakeCar.OpelCar.Id,
            IsHeadlightOn = true
        };

        // act
        var client = _factory.HttpClientFactory();

        var response = await client.PostAsJsonAsync("/api/Cars/Headlights-On-Or-Off-ByCarId", car);

        var carDto =
            JsonConvert.DeserializeObject<CustomResponseDto<CarDto>>(response.Content.ReadAsStringAsync().Result);

        // assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.NotEqual(FakeCar.OpelCar.IsHeadlightOn, carDto.Data.IsHeadlightOn);
    }

    [Fact]
    public async Task should_success_add_update_and_delete_car()
    {
        //arrange|add
        var car = new CreateCarCommand()
        {
            Brand = "Honda",
            Wheel = 4,
            SeatCapacity = 5,
            IsHeadlightOn = false,
            ColorId = FakeColor.BlackColor.Id
        };

        // act|add
        var client = _factory.HttpClientFactory();
        var response = await client.PostAsJsonAsync("/api/Cars", car);
        var createdItem =
            JsonConvert.DeserializeObject<CustomResponseDto<CarDto>>(response.Content.ReadAsStringAsync().Result);


        // assert|add
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.NotNull(createdItem.Data);

        //arrange|update
        var updateCar = new UpdateCarCommand()
        {
            Id = createdItem.Data.Id,
            Brand = "Mercedes",
            Wheel = 4,
            SeatCapacity = 5,
            IsHeadlightOn = true,
            ColorId = FakeColor.WhiteColor.Id
        };

        // act|update
        response = await client.PutAsJsonAsync("/api/Cars", updateCar);
        var updatedItem =
            JsonConvert.DeserializeObject<CustomResponseDto<CarDto>>(response.Content.ReadAsStringAsync().Result);

        // assert|updated
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.NotNull(updatedItem.Data);
        Assert.NotEqual(createdItem.Data.Brand, updatedItem.Data.Brand);
        Assert.NotEqual(createdItem.Data.IsHeadlightOn, updatedItem.Data.IsHeadlightOn);
        Assert.NotEqual(createdItem.Data.ColorId, updatedItem.Data.ColorId);


        // act|delete
        response = await client.DeleteAsync($"/api/Cars/{updatedItem.Data.Id}");

        // assert|updated
        Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
    }
}