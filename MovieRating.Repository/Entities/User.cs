using System.Collections.Generic;

namespace MovieRating.Repository.Entities
{
    public class User
    {
        public int Id { get; set; }

        public IEnumerable<MovieRatings> MovieRatings { get; set; }
    }
}
