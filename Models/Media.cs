namespace MyBookshelf.Models
{
	public abstract class Media : IRecommendable
	{
		public Media (long id, string title, List<string> createdBy, double rating, string comment, short ratedInYear)
		{
			Id = id;
			Title = title;
			CreatedBy = createdBy;
			Rating = rating;
			Comment = comment;
			RatedInYear = ratedInYear;
		}
		public Media(long id, string title, List<string> createdBy, string imageUrl, double rating, string comment, short ratedInYear)
		{
			Id = id;
			Title = title;
			CreatedBy = createdBy;
			ImageUrl = imageUrl;
			Rating = rating;
			Comment = comment;
			RatedInYear = ratedInYear;
		}
		public long Id { get; set; }
		public string Title { get; set; }
		public List<string> CreatedBy { get; set; }
		public string ImageUrl { get; set; }
		public double Rating { get; set; }
		public string Comment { get; set; }
		public short RatedInYear { get; set; }
	}
}
