using System.Collections.Generic;

namespace MovieRating.Domain.DTO
{
    /// <summary>
    /// User
    /// </summary>
    public class User
    {
        /// <summary>
        /// Users id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// List of moving ratings submitted by the user
        /// </summary>
        public List<MovieRatings> MovieRatings { get; set; }
    }
}
