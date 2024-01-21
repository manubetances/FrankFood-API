using Microsoft.AspNetCore.Mvc;
using ErrorOr;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace FrankFood.Controllers;

[ApiController]
[Route("[controller]")]
public class ApiController : ControllerBase
{
    // When we face a list of errors. The problem method is called
    protected IActionResult Problem(List<Error> errors)
    {
        // If all errors we get are validation problems
        if (errors.All(e => e.Type == ErrorType.Validation))
        {
            // 
            var modelStateDictionary = new ModelStateDictionary();
            // Add all the errors that occured to the dictionary
            // Itirate to all the errors, and add them with its error code and description
            foreach (var error in errors)
            {
                modelStateDictionary.AddModelError(error.Code, error.Description);
            }

            return ValidationProblem(modelStateDictionary);
        }

        // If theres any error that we do not expect, we return 500 internal server error
        if (errors.Any(e => e.Type == ErrorType.Unexpected))
        {
            return Problem();
        }

        // Take the first error encountered
        var firstError = errors[0];

        // Match the first error with its status code
        var statusCode = firstError.Type switch
        {
            ErrorType.NotFound => StatusCodes.Status404NotFound,
            ErrorType.Validation => StatusCodes.Status400BadRequest,
            ErrorType.Conflict => StatusCodes.Status409Conflict,
            _ => StatusCodes.Status500InternalServerError
        };

        // Then return the status code and the description of the error
        return Problem(statusCode: statusCode, title: firstError.Description);
    }
}