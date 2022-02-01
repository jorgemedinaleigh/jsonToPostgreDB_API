using Npgsql;
using orion_msdynamics_inbound_api.Models;

namespace orion_msdynamics_inbound_api.Data
{
    public class CuentaRepository
    {
        private const string CONNECTION_STRING = "Host=localhost:5432;" +
                                                 "Username=postgres;" +
                                                 "Password=sfr-66t.1337;" +
                                                 "Database=postgres";

        private NpgsqlConnection connection;

        public CuentaRepository()
        {
            connection = new NpgsqlConnection(CONNECTION_STRING);
            connection.Open();
        }

        public void AddCuenta(string cuenta)
        {
            string commandText = @"insert into public.""AccountLogs""(""JsonFile"") values ('@file');";
            using (var cmd = new NpgsqlCommand(commandText, connection))
            {
                cmd.Parameters.AddWithValue("file", cuenta);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
