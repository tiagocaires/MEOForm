using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace Meo.WebAPI.Controllers
{
    [ApiController]
    public abstract class ApiControllerBase : ControllerBase
    {
        private readonly List<ValidationFailure> _errors = new List<ValidationFailure>();

        protected ActionResult ApiResponse(object result = null)
        {
            if (ValidOperation())
                return Ok(result);
            
            return BadRequest(result);
        }

        protected void AddError(ValidationFailure error)
        {
            _errors.Add(error);
        }

        protected void AddErrors(List<ValidationFailure> errors)
        {
            _errors.AddRange(errors);
        }

        protected bool ValidOperation()
        {
            return !_errors.Any();
        }

        protected void CleanErrors()
        {
            _errors.Clear();
        }
    }
}
