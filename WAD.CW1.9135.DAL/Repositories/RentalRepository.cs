using WAD.CW1._9135.DAL.Data;
using WAD.CW1._9135.DAL.Models;
using WAD.CW1._9135.DAL.Services.Interfaces;

namespace WAD.CW1._9135.DAL.Services.Repositories
{
	public class RentalRepository : IRentalRepository
	{
		private readonly ApplicationDbContext _dbContext;

		public RentalRepository(ApplicationDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public IQueryable<Rental> GetAll()
		{
			return _dbContext.Rentals.AsQueryable();
		}

		public Rental GetById(int id)
		{
			return _dbContext.Rentals.FirstOrDefault(r => r.Id == id);
		}

		public void Add(Rental rental)
		{
			_dbContext.Rentals.Add(rental);
			_dbContext.SaveChanges();
		}

		public void Update(Rental rental)
		{
			_dbContext.Rentals.Update(rental);
			_dbContext.SaveChanges();
		}

		public void Delete(int id)
		{
			var rental = _dbContext.Rentals.FirstOrDefault(r => r.Id == id);
			if (rental != null)
			{
				_dbContext.Rentals.Remove(rental);
				_dbContext.SaveChanges();
			}
		}
	}
}
