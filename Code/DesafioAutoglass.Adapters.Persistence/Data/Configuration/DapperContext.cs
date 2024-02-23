using MySqlConnector;
using System.Data;

namespace DesafioAutoglass.Adapters.Persistence.Adapters.Configuration
{
    public class DapperContext
    {
        private readonly string _connectionString;

        public DapperContext()
        {
            _connectionString = "server=localhost;port=3306;database=autoglass;user=root;password=@Will00;Persist Security Info=False;Connect Timeout=300";
        }

        public IDbConnection CreateConnection() => new  MySqlConnection(_connectionString);
    }
}
