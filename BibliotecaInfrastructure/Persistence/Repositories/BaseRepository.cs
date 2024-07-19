using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaInfrastructure.Persistence.Repositories
{
    public abstract class BaseRepository
    {
        private SqlConnection? _connection;
        public static string _connectionString = String.Empty;
        public SqlConnection GetConnection(IConfiguration? _config)
        {
            _connectionString = _config.GetConnectionString("LibraryManagementConnection");
            _connection = new SqlConnection(_connectionString);
            if (_connection.State != ConnectionState.Open)
            {
                _connection.Open();
            }
            return _connection;
        }
    }
}
