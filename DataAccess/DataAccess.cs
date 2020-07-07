using System.Linq;
using System.Collections.Generic;
using System.Data;
using Dapper;
using MySql.Data.MySqlClient;

namespace DataAccess
{
    public class DataAccess
    {
        public List<T> LoadData<T, U>(string sql, U parameters, string connectionString)
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                List<T> rows = connection.Query<T>(sql, parameters).ToList();

                return rows;
            }
        }

        public void SaveData<T, U>(string sql, U parameters, string connectionString)
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                connection.Execute(sql, parameters);
            }
        }
    }
}
