using FluentValidation;
using FluentValidation.Results;
using Meo.Service.RequestModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meo.Service.Validation
{
    public class Validator<T> : AbstractValidator<T> where T : AModelRequest
    {
        public ValidationResult Validate(T command)
        {
            ValidationResult validation = base.Validate(command);
            return validation;
        }
    }
}
