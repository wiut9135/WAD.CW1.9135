using WAD.CW1._9135.DAL.Models;

namespace WAD.CW1._9135.DAL.Services.Interfaces
{
	public interface IRentalRepository
	{
		IQueryable<Rental> GetAll();
		Rental GetById(int id);
		void Add(Rental rental);
		void Update(Rental rental);
		void Delete(int id);
	}
}
