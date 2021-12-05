namespace MovieRating.Repository.Entities
{
    public class MovieRatings
    {
        public int UserId { get; set; }
        public int MovieId { get; set; }
        public decimal Rating { get; set; }

        public Movie Movie { get; set; }
        public User User { get; set; }
    }
}
