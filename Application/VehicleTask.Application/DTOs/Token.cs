﻿namespace VehicleTask.Application.DTOs;

public class Token
{
    public DateTime Expiration { get; set; }
    public string AccessToken { get; set; }
}