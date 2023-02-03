using AutoMapper;
using VehicleTask.Application.DTOs.Boats;
using VehicleTask.Application.DTOs.Buses;
using VehicleTask.Application.DTOs.Cars;
using VehicleTask.Application.DTOs.Colors;
using VehicleTask.Application.DTOs.Users;
using VehicleTask.Application.Features.Command.Boats.CreateBoat;
using VehicleTask.Application.Features.Command.Boats.HeadlightsOnOrOffByBoatId;
using VehicleTask.Application.Features.Command.Boats.UpdateBoat;
using VehicleTask.Application.Features.Command.Buses.CreateBus;
using VehicleTask.Application.Features.Command.Buses.HeadlightsOnOrOffByBusId;
using VehicleTask.Application.Features.Command.Buses.UpdateBus;
using VehicleTask.Application.Features.Command.Car.CreateCar;
using VehicleTask.Application.Features.Command.Car.HeadlightsOnOrOffByCarId;
using VehicleTask.Application.Features.Command.Car.UpdateCar;
using VehicleTask.Application.Features.Command.Color.CreateColor;
using VehicleTask.Application.Features.Command.Color.UpdateColor;
using VehicleTask.Application.Features.Command.Users.RegisterUser;
using VehicleTask.Domain.Models.Concrete;

namespace VehicleTask.Application.Mapper;

public class MapperProfile:Profile
{
    public MapperProfile()
    {
        CreateMap<User, UserListDto>().ReverseMap();
        CreateMap<User, RegisterUserCommand>().ReverseMap();
        
        CreateMap<Color,ColorDto>().ReverseMap();
        CreateMap<Color,ColorListDto>().ReverseMap();
        CreateMap<Color,CreateColorCommand>().ReverseMap();
        CreateMap<Color,UpdateColorCommand>().ReverseMap();
        
        CreateMap<Car,CarListDto>().ReverseMap();
        CreateMap<Car,CreateCarCommand>().ReverseMap();
        CreateMap<Car,UpdateCarCommand>().ReverseMap();
        CreateMap<Car,HeadlightsOnOrOffByCarIdCommand>().ReverseMap();
        
        CreateMap<Bus,BusListDto>().ReverseMap();
        CreateMap<Bus,CreateBusCommand>().ReverseMap();
        CreateMap<Bus,UpdateBusCommand>().ReverseMap();
        CreateMap<Bus,HeadlightsOnOrOffByBusIdCommand>().ReverseMap();
        
        CreateMap<Boat,BoatListDto>().ReverseMap();
        CreateMap<Boat,CreateBoatCommand>().ReverseMap();
        CreateMap<Boat,UpdateBoatCommand>().ReverseMap();
        CreateMap<Boat,HeadlightsOnOrOffByBoatIdCommand>().ReverseMap();
    }
}