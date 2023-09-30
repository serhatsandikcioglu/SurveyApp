using FluentValidation;
using SurveyApp.Data.DTO_s;
using SurveyApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Service.Validator
{
    public class QuestionValidator : AbstractValidator<QuestionDTO>
    {
        public QuestionValidator()
        {
            RuleFor(x => x.Text).NotEmpty().WithMessage("Text cannot be empty");
            RuleFor(x => x.Choices).NotEmpty().WithMessage("Choice cannot be empty")
                .ForEach(choiceRule =>
                {
                    choiceRule.NotNull().WithMessage("Choice cannot be null");
                });
        }
    }
}
