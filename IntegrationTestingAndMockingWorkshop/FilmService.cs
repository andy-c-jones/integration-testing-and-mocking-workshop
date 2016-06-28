namespace IntegrationTestingAndMockingWorkshop
{
    public class FilmService
    {
        private readonly IFilmRepository _filmRepository;

        public FilmService(IFilmRepository filmRepository)
        {
            _filmRepository = filmRepository;
        }

        public void AddFilm(string title, int year)
        {
            _filmRepository.Add(new Film(title, year));
        }
    }
}