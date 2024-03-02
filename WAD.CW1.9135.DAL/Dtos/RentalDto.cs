namespace WAD.CW1._9135.DAL.Dtos
{
	public class RentalDto
	{
		public int Id { get; set; }
		public int CarId { get; set; }
		public int CustomerId { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
		public decimal TotalCost { get; set; }
		public bool IsPaid { get; set; }
	}
}
