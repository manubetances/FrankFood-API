using Microsoft.AspNetCore.Mvc;

namespace FrankFood.Controllers;

public class ErrorController : ControllerBase
{
    [Route("/error")]
    public IActionResult Error()
    {
        return Problem();
    }
}