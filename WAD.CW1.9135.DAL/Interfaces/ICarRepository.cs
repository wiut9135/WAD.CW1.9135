using WAD.CW1._9135.DAL.Models;

namespace WAD.CW1._9135.DAL.Services.Interfaces
{
	public interface ICarRepository
	{
		IQueryable<Car> GetAll();
		Car GetById(int id);
		void Add(Car car);
		void Update(Car car);
		void Delete(int id);
	}
}
