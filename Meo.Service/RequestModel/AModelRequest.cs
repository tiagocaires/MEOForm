using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meo.Service.RequestModel
{
    public abstract class AModelRequest : ValidationResult
    {
        public ValidationResult Result { get; set; }

        public virtual bool IsValid()
        {
            return Result.IsValid;
        }
    }
}
