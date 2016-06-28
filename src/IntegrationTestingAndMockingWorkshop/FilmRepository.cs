using System;
using System.Data;
using System.Data.SqlClient;

namespace IntegrationTestingAndMockingWorkshop
{
    public class FilmRepository : IFilmRepository
    {
        private readonly string _connectionString;

        public FilmRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public AddResult Add(Film film)
        {
            try
            {
                using (var sqlConnection = new SqlConnection(_connectionString))
                {
                    sqlConnection.Open();
                    const string cmdText = "INSERT INTO Films (Title, Year) VALUES (@Title, @Year)";
                    var cmd = new SqlCommand(cmdText, sqlConnection);
                    cmd.Parameters.Add("Title", SqlDbType.NVarChar, -1).Value = film.Title;
                    cmd.Parameters.Add("Year", SqlDbType.Int).Value = film.Year;
                    cmd.ExecuteNonQuery();
                    return new AddResult(true);
                }
            }
            catch (Exception)
            {
                return new AddResult(false);
            }
        }
    }

    public class AddResult
    {
        public bool Successful { get; set; }

        public AddResult(bool successful)
        {
            Successful = successful;
        }
    }
}
