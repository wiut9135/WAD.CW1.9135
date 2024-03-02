using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WAD.CW1._9135.DAL.Dtos;
using WAD.CW1._9135.DAL.Models;
using WAD.CW1._9135.DAL.Services.Interfaces;

namespace WAD.CW1._9135.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CarsController : ControllerBase
	{
		private readonly ICarRepository _carRepository;
		private readonly IMapper _mapper;

		public CarsController(ICarRepository carRepository, IMapper mapper)
		{
			_carRepository = carRepository;
			_mapper = mapper;
		}

		[HttpGet]
		public IActionResult GetAllCars()
		{
			var cars = _carRepository.GetAll();
			var carDTOs = _mapper.Map<List<CarDto>>(cars);
			return Ok(carDTOs);
		}

		[HttpGet("{id}")]
		public IActionResult GetCarById(int id)
		{
			var car = _carRepository.GetById(id);
			if (car == null)
			{
				return NotFound();
			}

			var carDTO = _mapper.Map<CarDto>(car);
			return Ok(carDTO);
		}

		[HttpPost]
		public IActionResult AddCar([FromBody] CarDto carDto)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var car = _mapper.Map<Car>(carDto);
			_carRepository.Add(car);

			return Ok("Car have been added properly");
		}

		[HttpPut("{id}")]
		public IActionResult UpdateCar(int id, [FromBody] CarDto carDto)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var existingCar = _carRepository.GetById(id);
			if (existingCar == null)
			{
				return NotFound();
			}

			var updatedCar = _mapper.Map(carDto, existingCar);
			_carRepository.Update(updatedCar);

			return NoContent();
		}

		[HttpDelete("{id}")]
		public IActionResult DeleteCar(int id)
		{
			var car = _carRepository.GetById(id);
			if (car == null)
			{
				return NotFound();
			}

			_carRepository.Delete(id);

			return NoContent();
		}
	}
}
