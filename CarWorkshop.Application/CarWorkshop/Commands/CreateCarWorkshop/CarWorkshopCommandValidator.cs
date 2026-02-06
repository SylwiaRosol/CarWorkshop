using CarWorkshop.Domain.Interfaces;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Application.CarWorkshop.Commands.CreateCarWorkshop
{
    public class CarWorkshopCommandValidator : AbstractValidator<CreateCarWorkshopCommand>
    {
        public CarWorkshopCommandValidator(ICarWorkshopRespository respository)
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .Length(2, 20).WithMessage("Name must be between 2 and 20 characters.")
                .Custom((name, context) =>
                {
                    var existingCarWorkshop = respository.GetByName(name).Result;
                    if (existingCarWorkshop != null)
                    {
                        context.AddFailure($"{name} a car workshop with the same name already exists.");
                    }
                });

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description is required.");
            RuleFor(x => x.PhoneNumber)
                .MinimumLength(8)
                .MaximumLength(12); 
        }
    }
}
