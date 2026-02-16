namespace MyBookshelf.Models
{
	public interface IRecommendable
	{
		public double Rating { get; set; }
		public string Comment { get; set; }
		public short RatedInYear { get; set; }
	}
}
