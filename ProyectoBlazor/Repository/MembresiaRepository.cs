using System.Data;
using MySql.Data.MySqlClient;
using ProyectoBlazor.Modelos;


namespace SistemaGimnasio.Repository
{
    /// <summary>
    /// Repositorio para gestionar las operaciones relacionadas con las membresías en la base de datos.
    /// </summary>
    public class MembresiaRepository
    {
        /// <summary>
        /// Cadena de conexión a la base de datos MySQL.
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
        /// Crea una nueva membresía para un usuario específico.
        /// </summary>
        /// <param name="usuarioId">Identificador del usuario.</param>
        /// <param name="fechaInicio">Fecha de inicio de la membresía.</param>
        /// <param name="fechaFin">Fecha de finalización de la membresía.</param>
        public virtual void CrearMembresia(int usuarioId, DateOnly fechaInicio, DateOnly fechaFin)
        {
            try
            {
                using (var connection = new MySqlConnection(_connectionString))
                {
                    // Abre la conexión sincrónicamente
                    connection.Open();

                    string query = @"
            INSERT INTO Membresias (usuario_id, FechaInicio, FechaFin) 
            VALUES (@UsuarioId, @FechaInicio, @FechaFin);";

                    using (var command = new MySqlCommand(query, connection))
                    {
                        // Convierte las fechas a cadenas en formato 'yyyy-MM-dd'
                        string fechaInicioStr = fechaInicio.ToString("yyyy-MM-dd");
                        string fechaFinStr = fechaFin.ToString("yyyy-MM-dd");

                        // Agrega parámetros a la consulta
                        command.Parameters.AddWithValue("@UsuarioId", usuarioId);
                        command.Parameters.AddWithValue("@FechaInicio", fechaInicioStr);
                        command.Parameters.AddWithValue("@FechaFin", fechaFinStr);

                        // Ejecuta la consulta sincrónicamente
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (MySqlException ex)
            {
                // Imprime detalles de la excepción de MySQL
                Console.WriteLine($"Error al ejecutar la consulta MySQL: {ex.Message}");
                Console.WriteLine($"Código de error: {ex.ErrorCode}");
                Console.WriteLine($"StackTrace: {ex.StackTrace}");
            }
            catch (Exception ex)
            {
                // Imprime detalles de cualquier otra excepción
                Console.WriteLine($"Error inesperado: {ex.Message}");
                Console.WriteLine($"StackTrace: {ex.StackTrace}");
            }
        }


        /// <summary>
        /// Obtiene la membresía más reciente de un usuario.
        /// </summary>
        /// <param name="userId">Identificador del usuario.</param>
        /// <returns>Instancia de <see cref="Membresia"/> o <c>null</c> si no se encuentra.</returns>
        public virtual async Task<Membresia> ObtenerMembresiaPorUsuarioIdAsync(int userId)
        {
            Membresia membresia = null;

            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                string query = "SELECT * FROM Membresias WHERE usuario_id = @UsuarioID ORDER BY FechaFin DESC";

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

        /// <summary>
        /// Obtiene todas las membresías almacenadas en la base de datos.
        /// </summary>
        /// <returns>Lista de <see cref="Membresia"/> con todas las membresías.</returns>
        public virtual async Task<List<Membresia>> ObtenerTodasLasMembresiasAsync()
        {
            var membresias = new List<Membresia>();

            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                string query = "SELECT * FROM Membresias";

                using (var command = new MySqlCommand(query, connection))
                {
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var membresia = new Membresia(
                                reader.GetInt32("id"),
                                reader.GetInt32("usuario_id"),
                                reader.GetDateTime("FechaInicio"),
                                reader.GetDateTime("FechaFin")
                            );
                            membresias.Add(membresia);
                        }
                    }
                }
            }

            return membresias;
        }
    }
}