using CarWorkshop.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Application.CarWorkshop.Commands.EditCarWorkshop
{
    internal class EditCarWorkshopCommandHandler : IRequestHandler<EditCarWorkshopCommand>
    {
        private readonly ICarWorkshopRespository _repository;
        public EditCarWorkshopCommandHandler(ICarWorkshopRespository repository) 
        { 
            _repository = repository;
        }
        public async Task<Unit> Handle(EditCarWorkshopCommand request, CancellationToken cancellationToken)
        {
            var carWorkshop = await _repository.GetByEncodedName(request.EncodedName!);
            
            carWorkshop.Description = request.Description;
            carWorkshop.ContactDetails.City = request.City;
            carWorkshop.ContactDetails.Street = request.Street;
            carWorkshop.ContactDetails.PostalCode = request.PostalCode;
            carWorkshop.ContactDetails.PhoneNumber = request.PhoneNumber; 

            await _repository.Comit();

            return Unit.Value;
        }
    }
}
