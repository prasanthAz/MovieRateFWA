using Microsoft.AspNetCore.Mvc;
using Moq;
using dto = MovieRating.Domain.DTO;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace MovieRating.API.Tests.TopMovies
{
    [TestFixture]
    public class GetAllUsers : TopMoviesBase
    {

        [Test]
        public async Task Should_CallCorrectServiceMethodAsync()
        {
            //arrange/act
            await GetController().Get();

            //assert
            MockMovieService.Verify(s => s.TopMoviesAsync(It.IsAny<byte>()), Times.Once);
        }

        [TestCase(true)]
        [TestCase(false)]
        public void Should_ReturnNotFound_IfMoviesAreNullOrEmpty(bool isNull)
        {
            //arrange
            if (isNull)
            {
                MockMovieService.Setup(s => s.TopMoviesAsync(It.IsAny<byte>())).Returns(Task.FromResult(null as List<dto.Movie>));
            }
            else
            {
                MockMovieService.Setup(s => s.TopMoviesAsync(It.IsAny<byte>())).Returns(Task.FromResult(new List<dto.Movie>()));
            }

            //act
            var asyncResult = GetController().Get();

            //assert
            var result = asyncResult.Result;
            Assert.IsInstanceOf<NotFoundResult>(result);
        }

        [Test]
        public void Should_ReturnJsonResult()
        {
            //arrange
            MockMovieService.Setup(s => s.TopMoviesAsync(It.IsAny<byte>())).Returns(Task.FromResult(new List<dto.Movie> { new dto.Movie() }));

            //act
            var asyncResult = GetController().Get();

            //assert
            var result = asyncResult.Result;
            Assert.IsInstanceOf<JsonResult>(result);
        }

    }
}
