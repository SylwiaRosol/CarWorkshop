using CarWorkshop.Domain.Interfaces;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Application.CarWorkshop
{
    public class CarWorkshopDtoValidator : AbstractValidator<CarWorkshopDto>
    {
        public CarWorkshopDtoValidator(ICarWorkshopRespository respository)
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
                .Length(8, 12).When(x => !string.IsNullOrEmpty(x.PhoneNumber))
                .WithMessage("Phone number must be between 8 and 12 characters if provided.");
        }
    }
}
