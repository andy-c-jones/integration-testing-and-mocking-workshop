namespace IntegrationTestingAndMockingWorkshop
{
    public class FilmService
    {
        private readonly IFilmRepository _filmRepository;

        public FilmService(IFilmRepository filmRepository)
        {
            _filmRepository = filmRepository;
        }

        public AddResult AddFilm(string title, int year)
        {
            return _filmRepository.Add(new Film(title, year));
        }
    }
}