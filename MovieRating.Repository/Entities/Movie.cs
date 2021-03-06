using System.Collections.Generic;

namespace MovieRating.Repository.Entities
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public short YearOfRelease { get; set; }
        public short GenreId { get; set; }
        public byte RunningTime { get; set; }
        public decimal AverageRating { get; set; }

        public IEnumerable<MovieRatings> MovieRatings { get; set; }
    }
}
