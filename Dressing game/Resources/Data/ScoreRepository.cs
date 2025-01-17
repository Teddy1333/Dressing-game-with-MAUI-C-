//using Java.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Dressing_game.Resources.Data
{
    public class ScoreRepository
    {
        private readonly string _connectionString;

        public ScoreRepository()
        {
            _connectionString = App.ConnectionString;
        }

        public void SaveScore(int score)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = "INSERT INTO Scores (Score, DateRecorded) VALUES (@Score, @DateRecorded)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Score", score);
                    command.Parameters.AddWithValue("@DateRecorded", DateTime.Now);

                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
