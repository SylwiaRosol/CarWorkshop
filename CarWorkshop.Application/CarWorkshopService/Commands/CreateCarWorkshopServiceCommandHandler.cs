using CarWorkshop.Application.ApplicationUser;
using CarWorkshop.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Application.CarWorkshopService.Commands
{
    public class CreateCarWorkshopServiceCommandHandler : IRequestHandler<CreateCarWorkshopServiceCommand>
    {
        private readonly ICarWorkshopRespository _carWorkshopRepository;
        private readonly IUserContext _userContext; 
        private readonly ICarWorkshopServiceRepository _carWorkshopServiceRepository;

        public CreateCarWorkshopServiceCommandHandler(ICarWorkshopRespository CarWorkshopRepository, IUserContext userContext,
            ICarWorkshopServiceRepository carWorkshopServiceRepository )
        {
            _carWorkshopRepository = CarWorkshopRepository;
            _userContext = userContext;
            _carWorkshopServiceRepository = carWorkshopServiceRepository;
        }


        public async Task<Unit> Handle(CreateCarWorkshopServiceCommand request, CancellationToken cancellationToken)
        {
           
            
            var carWorkshop = await _carWorkshopRepository.GetByEncodedName(request.CarWorkshopEncodedName!);

            var user = _userContext.GetCurrentUser();
            var isEditable = user != null && carWorkshop != null && (carWorkshop.CreatedById == user.Id || user.IsInRole("Admin"));

            if (!isEditable)
            {
                return Unit.Value;
            }

            var carWorkshopService = new Domain.Entities.CarWorkshopService()
            {
                Cost = request.Cost,
                Description = request.Description,
               
                CarWorkshopId = carWorkshop.Id,
            };

            await _carWorkshopServiceRepository.Create(carWorkshopService);

            return Unit.Value;

        }
    }
}
