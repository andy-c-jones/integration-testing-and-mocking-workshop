using System.Data;
using System.Data.SqlClient;

namespace IntegrationTestingAndMockingWorkshop
{
    public class FilmRepository
    {
        public void Add(Film film)
        {
            using (var sqlConnection = new SqlConnection("Data Source=.;Initial Catalog=Films;Integrated Security=True"))
            {
                sqlConnection.Open();
                const string CmdText = "INSERT INTO Films (Title, Year) VALUES (@Title, @Year)";
                var cmd = new SqlCommand(CmdText, sqlConnection);
                cmd.Parameters.Add("Title", SqlDbType.NVarChar, -1).Value = film.Title;
                cmd.Parameters.Add("Year", SqlDbType.Int).Value = film.Year;
                cmd.ExecuteNonQuery();
            }
        }
    }
}
