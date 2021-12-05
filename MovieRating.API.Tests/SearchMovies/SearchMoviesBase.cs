using Moq;
using MovieRating.API.Controllers;
using MovieRating.Business.Interfaces;
using NUnit.Framework;

namespace MovieRating.API.Tests.SearchMovies
{
    public class SearchMoviesBase
    {

        protected Mock<IMovieService> MockMovieService;

        [SetUp]
        protected void Setup()
        {
            MockMovieService = new Mock<IMovieService>();
        }

        protected SearchMoviesController GetController()
        {
            return new SearchMoviesController(MockMovieService.Object);
        }

    }
}
