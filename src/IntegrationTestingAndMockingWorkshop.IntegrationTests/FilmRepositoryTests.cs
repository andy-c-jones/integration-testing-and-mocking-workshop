﻿using NUnit.Framework;

namespace IntegrationTestingAndMockingWorkshop.IntegrationTests
{
    [TestFixture]
    public class FilmRepositoryTests
    {
        private FilmRepository _repository;

        [SetUp]
        public void GivenAFilmRepository()
        {
            SqlHelper.TruncateFilmsTable();

            _repository = new FilmRepository("Data Source=.;Initial Catalog=Films;Integrated Security=True");
        }

        [Test]
        [TestCase("The Shawshank Redemption")]
        [TestCase("The Dark Knight")]
        [TestCase("The Godfather")]
        [TestCase("Schindler's List")]
        public void WhenASingleFilmIsAddedThenTheFilmsTitleIsPersistedInTheDatabase(string expectedTitle)
        {
            _repository.Add(new Film(expectedTitle, 1994));

            var actualTitle = SqlHelper.GetFirstRowsFilmName();

            Assert.That(actualTitle, Is.EqualTo(expectedTitle));
        }

        [Test]
        [TestCase(1994)]
        [TestCase(2016)]
        [TestCase(2050)]
        [TestCase(1971)]
        public void WhenASingleFilmIsAddedThenTheFilmsYearIsPersistedInTheDatabase(int expectedYear)
        {
            _repository.Add(new Film("A Film", expectedYear));

            var actualYear = SqlHelper.GetFirstRowsFilmYear();

            Assert.That(actualYear, Is.EqualTo(expectedYear));
        }

        [Test]
        public void WhenAFilmFailsToBeAddedThenTheReturnValueShouldIndicateFailure()
        {
            var result = _repository.Add(new Film("A Film", 1954));

            Assert.That(result.Successful, Is.True);
        }
    }

    [TestFixture]
    public class FilmRepositoryFailureTests
    {
        private FilmRepository _repository;

        [SetUp]
        public void GivenAFilmRepositoryWithAnIncorrectConnectionString()
        {
            SqlHelper.TruncateFilmsTable();

            _repository = new FilmRepository("BrokenConnectionString");
        }

        [Test]
        public void WhenAFilmFailsToBeAddedThenTheReturnValueShouldIndicateFailure()
        {
            var result = _repository.Add(new Film("A Film", 1954));

            Assert.That(result.Successful, Is.False);
        }
    }
}
