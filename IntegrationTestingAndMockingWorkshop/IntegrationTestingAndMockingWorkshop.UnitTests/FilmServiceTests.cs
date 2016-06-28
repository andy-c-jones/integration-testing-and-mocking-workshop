using Moq;
using NUnit.Framework;

namespace IntegrationTestingAndMockingWorkshop.UnitTests
{
    [TestFixture]
    public class FilmServiceTests
    {
        [Test]
        public void GivenNoExistingFilmsWhenAddFilmCalledThenTheFilmIsAddedToTheDatabase()
        {
            var filmRepository = new Mock<IFilmRepository>();
            var filmService = new FilmService(filmRepository.Object);

            filmService.AddFilm("Shawshank Redemption", 1994);

            filmRepository.Verify(r => r.Add(It.Is<Film>(f => f.Title == "Shawshank Redemption" && f.Year == 1994)));
        }
    }
}
