using MovieRating.Domain.DTO;
using MovieRating.Repository.Interfaces;
using System.Linq;
using System.Threading.Tasks;
using Repo = MovieRating.Repository.Entities;

namespace MovieRating.Repository
{
    public class RatingRepository : BaseRepository, IRatingRepository
    {
        public RatingRepository(Context context) : base(context) { }

        public async Task<bool> SaveRatingAsync(MovieRatings movieRating)
        {
            var rating = _context.MovieRatingDbSet.FirstOrDefault(mr => mr.MovieId == movieRating.MovieId && mr.UserId == movieRating.UserId);

            if (rating != null)
            {
                rating.Rating = movieRating.Rating;
            }
            else
            {
                rating = new Repo.MovieRatings
                {
                    MovieId = movieRating.MovieId,
                    UserId = movieRating.UserId,
                    Rating = movieRating.Rating
                };

                _context.MovieRatingDbSet.Add(rating);
            }

            return await _context.SaveChangesAsync() > 0;
        }

    }
}
