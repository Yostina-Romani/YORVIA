using Microsoft.AspNetCore.Mvc;
using YORVIA.Application.Common;
using YORVIA.Application.Features.Courses.DTOs;

namespace YORVIA.API.Extensions
{
    public static class ResponseExtensions
    {
        public static IActionResult ToActionResult<T>(this ControllerBase controllerBase, Response<T> response)
        {
            if (response.Success)
            {
                return controllerBase.Ok(response);
            }

            return response.ErrorType switch
            {
                ErrorType.Validation => controllerBase.BadRequest(response),
                ErrorType.Forbidden=>controllerBase.StatusCode(StatusCodes.Status403Forbidden,response),
                ErrorType.NotFound=>controllerBase.NotFound(response),
                ErrorType.Conflict=>controllerBase.Conflict(response),
                ErrorType.Unauthorized=>controllerBase.Unauthorized(response),

                _                    =>controllerBase.StatusCode(StatusCodes.Status500InternalServerError,response),


            };



        }
    }
}
