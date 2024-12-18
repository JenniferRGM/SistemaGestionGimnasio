using System.Data;
using MySql.Data.MySqlClient;
using ProyectoBlazor.Modelos;
using ProyectoBlazor.Models;

namespace ProyectoBlazor.Repository
{
    public class MetricasProgresoRepository
    {

        private readonly string _connectionString;


        public MetricasProgresoRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<List<MetricasProgreso>> ObtenerMetricasPorUsuarioId(int usuarioId)
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
                        // Iterar sobre todas las filas
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

        public void CrearMetricaProgreso(int usuarioId, string parte, int cantidad, DateTime fecha)
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

                    command.ExecuteNonQuery(); // Ejecutar el comando sincrónicamente
                }
            }
        }




    }



}
