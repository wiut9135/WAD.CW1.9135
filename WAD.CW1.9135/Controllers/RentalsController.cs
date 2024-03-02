using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WAD.CW1._9135.DAL.Dtos;
using WAD.CW1._9135.DAL.Models;
using WAD.CW1._9135.DAL.Services.Interfaces;

namespace WAD.CW1._9135.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class RentalsController : ControllerBase
	{
		private readonly IRentalRepository _rentalRepository;
		private readonly IMapper _mapper;

		public RentalsController(IRentalRepository rentalRepository, IMapper mapper)
		{
			_rentalRepository = rentalRepository;
			_mapper = mapper;
		}

		[HttpGet]
		public IActionResult GetAllRentals()
		{
			var rentals = _rentalRepository.GetAll();
			var rentalDTOs = _mapper.Map<List<RentalDto>>(rentals);
			return Ok(rentalDTOs);
		}

		[HttpGet("{id}")]
		public IActionResult GetRentalById(int id)
		{
			var rental = _rentalRepository.GetById(id);
			if (rental == null)
			{
				return NotFound();
			}

			var rentalDTO = _mapper.Map<RentalDto>(rental);
			return Ok(rentalDTO);
		}

		[HttpPost]
		public IActionResult AddRental([FromBody] RentalDto rentalDto)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var rental = _mapper.Map<Rental>(rentalDto);
			_rentalRepository.Add(rental);
			return Ok("Rental have been successfuly created");
		}

		[HttpPut("{id}")]
		public IActionResult UpdateRental(int id, [FromBody] RentalDto rentalDto)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var existingRental = _rentalRepository.GetById(id);
			if (existingRental == null)
			{
				return NotFound();
			}

			var updatedRental = _mapper.Map(rentalDto, existingRental);
			_rentalRepository.Update(updatedRental);

			return NoContent();
		}

		[HttpDelete("{id}")]
		public IActionResult DeleteRental(int id)
		{
			var rental = _rentalRepository.GetById(id);
			if (rental == null)
			{
				return NotFound();
			}

			_rentalRepository.Delete(id);

			return NoContent();
		}
	}
}
