using CarWorkshop.Application.CarWorkshop.Commands.CreateCarWorkshop;
using CarWorkshop.Application.CarWorkshop.Commands.EditCarWorkshop;
using CarWorkshop.Application.CarWorkshop.Queries.GetAllCarWorkshops;
using CarWorkshop.Application.CarWorkshop.Queries.GetCarWorkshopByEncodedName;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarWorkshop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarWorkshopApiController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CarWorkshopApiController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var carWorkshops = await _mediator.Send(new GetAllCarWorkshopsQuery());
            return Ok(carWorkshops);
        }
        [HttpGet("{encodedName}")]
        public async Task<IActionResult> Get(string encodedName)
        {
            var dto = await _mediator.Send(new GetCarWorkshopByEncodedNameQuery(encodedName));

            if (dto == null)
                return NotFound();

            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCarWorkshopCommand command)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _mediator.Send(command);

            return CreatedAtAction(nameof(Get), new { encodedName = command.EncodedName }, new
            {
                command.Name,
                command.EncodedName
            });
        }

        [HttpPut("{encodedName}")]
        public async Task<IActionResult> Edit(string encodedName, EditCarWorkshopCommand command)
        {
            command.EncodedName = encodedName;

            await _mediator.Send(command);

            return NoContent();
        }





    }
}
