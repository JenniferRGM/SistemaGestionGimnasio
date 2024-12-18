using System.Data;
using MySql.Data.MySqlClient;
using ProyectoBlazor.Modelos;
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

        public void CrearMembresia(int usuarioId, DateOnly fechaInicio, DateOnly fechaFin)
        {
            try
            {
                using (var connection = new MySqlConnection(_connectionString))
                {
                    // Abrir la conexión sincrónicamente
                    connection.Open();

                    string query = @"
            INSERT INTO Membresias (usuario_id, FechaInicio, FechaFin) 
            VALUES (@UsuarioId, @FechaInicio, @FechaFin);";

                    using (var command = new MySqlCommand(query, connection))
                    {
                        // Convertir las fechas a cadenas en formato 'yyyy-MM-dd'
                        string fechaInicioStr = fechaInicio.ToString("yyyy-MM-dd");
                        string fechaFinStr = fechaFin.ToString("yyyy-MM-dd");

                        // Agregar parámetros a la consulta
                        command.Parameters.AddWithValue("@UsuarioId", usuarioId);
                        command.Parameters.AddWithValue("@FechaInicio", fechaInicioStr);
                        command.Parameters.AddWithValue("@FechaFin", fechaFinStr);

                        // Ejecutar la consulta sincrónicamente
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (MySqlException ex)
            {
                // Imprimir detalles de la excepción de MySQL
                Console.WriteLine($"Error al ejecutar la consulta MySQL: {ex.Message}");
                Console.WriteLine($"Código de error: {ex.ErrorCode}");
                Console.WriteLine($"StackTrace: {ex.StackTrace}");
            }
            catch (Exception ex)
            {
                // Imprimir detalles de cualquier otra excepción
                Console.WriteLine($"Error inesperado: {ex.Message}");
                Console.WriteLine($"StackTrace: {ex.StackTrace}");
            }
        }



        public async Task<Membresia> ObtenerMembresiaPorUsuarioIdAsync(int userId)
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

        public async Task<List<Membresia>> ObtenerTodasLasMembresiasAsync()
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