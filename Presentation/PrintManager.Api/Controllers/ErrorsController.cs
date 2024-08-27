using Microsoft.AspNetCore.Mvc;

namespace PrintManager.Api.Controllers;

public class ErrorsController : ApiController
{
    [Route("/error")]
    public IActionResult Error()
    {
        return Problem();
    }
}
