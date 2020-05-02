using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Npgsql;

namespace Infraestructure.Database {
    public class ConnectionProvider {
        private readonly string ConnectionString;
        private NpgsqlConnection Connection;

        public ConnectionProvider(string connectionString) {
            ConnectionString = connectionString;
        }
        public async Task EstablishConnection() {
            Connection = new NpgsqlConnection(ConnectionString);
            await Connection.OpenAsync();
        }
 
        public void Close() {
            Connection.Close();
        }

        public IEnumerable<T> Query<T>(string sql, object param = null, int? commandTimeout = null) {
            return Connection.Query<T>(sql,param).ToList();
        }

        public int Execute(string sql, object param = null) {
            return Connection.Execute(sql, param);
        }

    }
}