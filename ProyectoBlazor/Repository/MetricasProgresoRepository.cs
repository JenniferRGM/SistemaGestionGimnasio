using System.Data;
using MySql.Data.MySqlClient;
using ProyectoBlazor.Modelos;


namespace ProyectoBlazor.Repository
{
    /// <summary>
    /// Repositorio para gestionar las operaciones relacionadas con las métricas de progreso en la base de datos.
    /// </summary>
    public class MetricasProgresoRepository
    {
        
        /// <summary>
        /// Cadena de conexión a la base de datos MySQL.
        /// </summary>
        private readonly string _connectionString;


        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="MetricasProgresoRepository"/>.
        /// </summary>
        /// <param name="connectionString">Cadena de conexión a la base de datos.</param>
        public MetricasProgresoRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        /// <summary>
        /// Obtiene las métricas de progreso para un usuario específico.
        /// </summary>
        /// <param name="usuarioId">Identificador del usuario.</param>
        /// <returns>Lista de <see cref="MetricasProgreso"/> asociadas al usuario.</returns>
        public virtual async Task<List<MetricasProgreso>> ObtenerMetricasPorUsuarioId(int usuarioId)
        {
            List<MetricasProgreso> metricasProgresoList = new List<MetricasProgreso>();

            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                string query = "SELECT * FROM metricas_progreso WHERE usuario_id = @UsuarioID";

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UsuarioID", usuarioId);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        // Itera sobre todas las filas
                        while (await reader.ReadAsync())
                        {
                            var metricasProgreso = new MetricasProgreso(
                                reader.GetInt32("id"),
                                reader.GetInt32("usuario_id"),
                                reader.GetDateTime("fecha"),
                                reader.GetString("parte"),
                                reader.GetInt32("cantidad")
                            );

                            metricasProgresoList.Add(metricasProgreso);
                        }
                    }
                }
            }

            return metricasProgresoList;
        }

        /// <summary>
        /// Crea una nueva métrica de progreso para un usuario.
        /// </summary>
        /// <param name="usuarioId">Identificador del usuario.</param>
        /// <param name="parte">Parte del cuerpo o sección asociada a la métrica.</param>
        /// <param name="cantidad">Cantidad registrada en la métrica.</param>
        /// <param name="fecha">Fecha en que se registra la métrica.</param>
        public virtual void CrearMetricaProgreso(int usuarioId, string parte, int cantidad, DateTime fecha)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open(); // Conexión sincrónica

                string query = "INSERT INTO metricas_progreso (usuario_id, parte, cantidad, fecha) VALUES (@UsuarioID, @Parte, @Cantidad, @Fecha)";

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UsuarioID", usuarioId);
                    command.Parameters.AddWithValue("@Parte", parte);
                    command.Parameters.AddWithValue("@Cantidad", cantidad);
                    command.Parameters.AddWithValue("@Fecha", fecha);

                    command.ExecuteNonQuery(); // Ejecuta el comando sincrónicamente
                }
            }
        }

    }



}
