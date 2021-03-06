using Microsoft.AspNetCore.Mvc;
using Moq;
using MovieRating.Domain.DTO;
using MovieRating.Domain.Enums.Validation;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;
using dto = MovieRating.Domain.DTO;

namespace MovieRating.API.Tests.SearchMovies
{
    [TestFixture]
    public class Get : SearchMoviesBase
    {

        [TestCase(MovieSearchValidationResults.InvalidCriteria)]
        [TestCase(MovieSearchValidationResults.NoCriteria)]
        public void Should_ReturnExpectedResponseWhen_Invalid(MovieSearchValidationResults validationResult)
        {
            //arrange
            MockMovieService.Setup(s => s.ValidateSearchCriteria(It.IsAny<MovieSearchCriteria>())).Returns(validationResult);

            //act
            var asycResult = GetController().Get(new MovieSearchCriteria());

            //assert
            var result = asycResult.Result;
            switch (validationResult)
            {
                case MovieSearchValidationResults.InvalidCriteria:
                case MovieSearchValidationResults.NoCriteria:
                    Assert.IsInstanceOf<BadRequestObjectResult>(result);
                    var badRequest = result as BadRequestObjectResult;
                    Assert.AreEqual(validationResult.ToString(), badRequest.Value);
                    break;
            }
        }

        [TestCase(true)]
        [TestCase(false)]
        public void Should_ReturnNotFoundWhen_ResultIsNullOrEmpty(bool isNull)
        {
            //arrange
            MockMovieService.Setup(s => s.ValidateSearchCriteria(It.IsAny<MovieSearchCriteria>())).Returns(MovieSearchValidationResults.OK);
            if (isNull)
            {
                MockMovieService.Setup(s => s.SearchMoviesAsync(It.IsAny<MovieSearchCriteria>())).Returns(Task.FromResult(null as List<dto.Movie>));
            }
            else
            {
                MockMovieService.Setup(s => s.SearchMoviesAsync(It.IsAny<MovieSearchCriteria>())).Returns(Task.FromResult(new List<dto.Movie>()));
            }

            //act
            var asyncResult = GetController().Get(new MovieSearchCriteria());

            //assert
            var result = asyncResult.Result;
            Assert.IsInstanceOf<NotFoundResult>(result);

        }

        [Test]
        public void Should_ReturnJson()
        {
            //arrange
            MockMovieService.Setup(s => s.ValidateSearchCriteria(It.IsAny<MovieSearchCriteria>())).Returns(MovieSearchValidationResults.OK);
            MockMovieService.Setup(s => s.SearchMoviesAsync(It.IsAny<MovieSearchCriteria>())).Returns(Task.FromResult(new List<dto.Movie> { new dto.Movie()}));

            //act
            var jsonAsyncResult = GetController().Get(new MovieSearchCriteria());

            //assert
            var jsonResult = jsonAsyncResult.Result;
            Assert.IsInstanceOf<JsonResult>(jsonResult);
        }
    }
}
