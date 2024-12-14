using System.Data;
using MySql.Data.MySqlClient;
using SistemaGestionGimnasio.Modelos;

namespace SistemaGimnasio.Repository
{
    public class MembresiaRepository
    {
        private readonly string _connectionString;

        public MembresiaRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<Membresia> ObtenerMembresiaPorUsuarioIdAsync(int userId)
        {
            Membresia membresia = null;

            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                string query = "SELECT * FROM Membresias WHERE usuario_id = @UsuarioID";

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UsuarioID", userId);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            membresia = new Membresia(
                                reader.GetInt32("id"),
                                reader.GetInt32("usuario_id"),
                                reader.GetDateTime("FechaInicio"),
                                reader.GetDateTime("FechaFin")
                            );
                        }
                    }
                }
            }

            return membresia;
        }




    }
}
