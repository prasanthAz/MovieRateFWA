using Moq;
using MovieRating.API.Controllers;
using MovieRating.Business.Interfaces;
using NUnit.Framework;

namespace MovieRating.API.Tests.SaveMovieRating
{
    public class SaveMovieRatingBase
    {

        protected Mock<IRatingService> MockRatingService;

        public SaveMovieRatingBase()
        {
            MockRatingService = new Mock<IRatingService>();
        }

        [SetUp]
        protected void SetUp()
        {
            
        }

        protected SaveMovieRatingController GetController()
        {
            return new SaveMovieRatingController(MockRatingService.Object);
        }

    }
}
