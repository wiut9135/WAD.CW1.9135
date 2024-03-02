using AutoMapper;
using WAD.CW1._9135.DAL.Dtos;
using WAD.CW1._9135.DAL.Models;

namespace WAD.CW1._9135.DAL.MappingProfile
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<Car, CarDto>();
			CreateMap<CarDto, Car>();

			CreateMap<Rental, RentalDto>();
			CreateMap<RentalDto, Rental>();
		}
	}
}
