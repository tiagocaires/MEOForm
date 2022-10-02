using FluentValidation;
using Meo.Service.RequestModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meo.Service.Validation
{
    public abstract class FormValidation<T> : Validator<T> where T : FormModelValidationRequest
    {
        protected void ValidateCampaignId()
        {
            RuleFor(x => x.CampaignId)
                .NotEqual(0)
                .WithMessage("Campaign should be informed");
        }

        protected void ValidatePersion()
        {
            RuleFor(x => x.Person)
                .NotNull()
                .WithMessage("Person should be informed");
        }

        protected void ValidateAnswer()
        {
            RuleFor(x => x.Answers)
                .NotEmpty()
                .WithMessage("Answers should be informed");
        }
    }
}
