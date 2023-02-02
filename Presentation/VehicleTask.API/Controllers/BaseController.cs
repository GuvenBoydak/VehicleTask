using Microsoft.AspNetCore.Mvc;
using VehicleTask.Application.DTOs.Responce;

namespace VehicleTask.API.Controllers;

public class BaseController: ControllerBase
{
    [NonAction]
    public IActionResult CreateActionResult<T>(CustomResponseDto<T> responseDto)
    {
        if (responseDto.StatusCode == 204)
            return new ObjectResult(null) { StatusCode = responseDto.StatusCode };

        return new ObjectResult(responseDto) { StatusCode = responseDto.StatusCode };
    }
}