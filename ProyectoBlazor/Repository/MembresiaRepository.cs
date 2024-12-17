using System.Data;
using MySql.Data.MySqlClient;
using SistemaGestionGimnasio.Modelos;

namespace SistemaGimnasio.Repository
{
    /// <summary>
    /// Repositorio que gestiona las operaciones relacionadas con las membresías en la base de datos.
    /// </summary>
    public class MembresiaRepository
    {
        /// <summary>
        /// Cadena de conexión a la base de datos.
        /// </summary>
        private readonly string _connectionString;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="MembresiaRepository"/>.
        /// </summary>
        /// <param name="connectionString">Cadena de conexión a la base de datos.</param>
        public MembresiaRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        /// <summary>
        /// Obtiene la membresía asociada a un usuario específico.
        /// </summary>
        /// <param name="userId">Identificador único del usuario.</param>
        /// <returns>Objeto <see cref="Membresia"/> con los datos de la membresía o null si no se encuentra.</returns>

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
