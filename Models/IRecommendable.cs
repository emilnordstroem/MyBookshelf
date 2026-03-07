namespace MyBookshelf.Models
{
	public interface IRecommendable
	{
		public int Rating { get; set; }
		public string Comment { get; set; }
		public DateTime Date { get; set; }
	}
}
