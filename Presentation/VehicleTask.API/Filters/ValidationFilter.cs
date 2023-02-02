using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using VehicleTask.Application.DTOs.Responce;

namespace VehicleTask.API.Filters;

public class ValidationFilter : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        if (!context.ModelState.IsValid)
        {
            List<string> errors = context.ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage)
                .ToList();

            context.Result =
                new BadRequestObjectResult(CustomResponseDto<NoContentDto>.Fail(404, errors));
        }
    }
}