using Microsoft.EntityFrameworkCore;
using WAD.CW1._9135.DAL.Data;
using WAD.CW1._9135.DAL.Models;
using WAD.CW1._9135.DAL.Services.Interfaces;

namespace WAD.CW1._9135.DAL.Services.Repositories
{
	public class CarRepository : ICarRepository
	{
		private readonly ApplicationDbContext _dbContext;

		public CarRepository(ApplicationDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public IQueryable<Car> GetAll()
		{
			return _dbContext.Cars.AsQueryable().Include(c => c.Rentals);
		}

		public Car GetById(int id)
		{
			return _dbContext.Cars.FirstOrDefault(c => c.Id == id);
		}

		public void Add(Car car)
		{
			_dbContext.Cars.Add(car);
			_dbContext.SaveChanges();
		}

		public void Update(Car car)
		{
			_dbContext.Cars.Update(car);
			_dbContext.SaveChanges();
		}

		public void Delete(int id)
		{
			var car = _dbContext.Cars.FirstOrDefault(c => c.Id == id);
			if (car != null)
			{
				_dbContext.Cars.Remove(car);
				_dbContext.SaveChanges();
			}
		}
	}
}
