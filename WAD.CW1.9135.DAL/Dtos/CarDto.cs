﻿namespace WAD.CW1._9135.DAL.Dtos
{
	public class CarDto
	{
		public int Id { get; set; }
		public string Make { get; set; }
		public string Model { get; set; }
		public int Year { get; set; }
		public decimal PricePerDay { get; set; }
		public bool IsAvailable { get; set; }
	}
}
