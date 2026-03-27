using Microsoft.AspNetCore.Mvc;
using Project.Utility;

namespace Project.Api.Controller;

public class BaseApiController : ControllerBase
{
    protected new IActionResult Ok()
    {
        return base.Ok(Envelope.Ok());
    }

    protected IActionResult Ok<T>(T result)
    {
        return base.Ok(Envelope.Ok(result));
    }

    protected IActionResult Error(string errorMessage)
    {
        return BadRequest(Envelope.ErrorMessage(errorMessage));
    }
}