using Moq;
using MovieRating.API.Controllers;
using MovieRating.Business.Interfaces;
using NUnit.Framework;

namespace MovieRating.API.Tests.Movie
{
    public class MovieBase
    {

        protected Mock<IMovieService> MockMovieService;

        [SetUp]
        protected void Setup()
        {
            MockMovieService = new Mock<IMovieService>();
        }

        protected MovieController GetController()
        {
            return new MovieController(MockMovieService.Object);
        }

    }
}
