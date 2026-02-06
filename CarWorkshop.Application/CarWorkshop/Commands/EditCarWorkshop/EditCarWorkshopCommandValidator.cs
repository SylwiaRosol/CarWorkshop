using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Application.CarWorkshop.Commands.EditCarWorkshop
{
    public class EditCarWorkshopCommandValidator :AbstractValidator<EditCarWorkshopCommand>
    {
        public EditCarWorkshopCommandValidator()
        {
            RuleFor(x => x.Description)
               .NotEmpty().WithMessage("Description is required.");

            RuleFor(x => x.PhoneNumber)
                  .MinimumLength(8)
                  .MaximumLength(12);
        }

    }
}
