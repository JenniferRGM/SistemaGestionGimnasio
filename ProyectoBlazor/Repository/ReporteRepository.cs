using System.Data;
using MySql.Data.MySqlClient;

namespace SistemaGimnasio.Repository
{
    public class ReporteRepository
    {
        // Cadena de conexión a la base de datos
        private readonly string _connectionString;

        // Constructor que inicializa el repositorio con la cadena de conexión
        public ReporteRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        /// <summary>
        /// Obtiene el crecimiento de matrículas agrupadas por mes.
        /// </summary>
        /// <returns>Lista de tuplas con la fecha, número de nuevas matrículas y el total acumulado de matrículas.</returns>
        public async Task<List<(DateTime Fecha, int NuevasMatriculas, int TotalMatriculas)>> ObtenerCrecimientoMatriculasAsync()
        {
            var resultados = new List<(DateTime Fecha, int NuevasMatriculas, int TotalMatriculas)>();

            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                // Consulta SQL que obtiene el conteo de matrículas por mes/año
                var query = @"
                       SELECT 
                       CAST(DATE_FORMAT(fecha_matricula, '%Y-%m-01') AS DATETIME) AS Fecha, 
                       COUNT(*) AS NuevasMatriculas
                       FROM matriculas
                       GROUP BY DATE_FORMAT(fecha_matricula, '%Y-%m')
                       ORDER BY Fecha;
                       ";

                using (var command = new MySqlCommand(query, connection))
                {
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        int totalMatriculasHastaAhora = 0; // Variable para llevar el total acumulado de matrículas

                        while (await reader.ReadAsync())
                        {
                            var fecha = reader.GetDateTime("Fecha");
                            var nuevas = reader.GetInt32("NuevasMatriculas");

                            totalMatriculasHastaAhora += nuevas; // Actualiza el total acumulado

                            resultados.Add((fecha, nuevas, totalMatriculasHastaAhora));
                        }
                    }
                }
            }

            return resultados;
        }

        /// <summary>
        /// Obtiene un informe contable con ingresos y gastos en un rango de fechas.
        /// </summary>
        /// <param name="inicio">Fecha de inicio del rango.</param>
        /// <param name="fin">Fecha de fin del rango.</param>
        /// <returns>Lista de tuplas con la fecha, ingreso total y gasto total.</returns>
        public async Task<List<(DateTime Fecha, decimal Ingreso, decimal Gasto)>> ObtenerInformeContableAsync(DateTime inicio, DateTime fin)
        {
            var resultados = new List<(DateTime Fecha, decimal Ingreso, decimal Gasto)>();

            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                // Consulta para obtener los ingresos y egresos dentro del rango de fechas
                var query = @"
            SELECT 
                i.Fecha AS Fecha,
                IFNULL(SUM(i.Monto), 0) AS Ingreso,
                IFNULL(SUM(e.Monto), 0) AS Gasto
            FROM ingresos i
            LEFT JOIN egresos e ON i.Fecha = e.Fecha
            WHERE i.Fecha BETWEEN @Inicio AND @Fin
            GROUP BY i.Fecha
            ORDER BY i.Fecha";

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Inicio", inicio);
                    command.Parameters.AddWithValue("@Fin", fin);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var fecha = reader.GetDateTime("Fecha");
                            var ingreso = reader.GetDecimal("Ingreso");
                            var gasto = reader.GetDecimal("Gasto");

                            resultados.Add((fecha, ingreso, gasto));
                        }
                    }
                }
            }

            return resultados;
        }

        /// <summary>
        /// Obtiene las clases más reservadas en el gimnasio.
        /// </summary>
        /// <returns>Lista de tuplas con el nombre de la clase, horario y número de reservas.</returns>
        public async Task<List<(string Clase, string Horario, int Reservas)>> ObtenerClasesMasReservadasAsync()
        {
            var resultados = new List<(string Clase, string Horario, int Reservas)>();

            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var query = @"
            SELECT c.nombre AS Clase, 
                   ce.fecha AS Horario, 
                   COUNT(cr.id) AS TotalReservas
            FROM clases c
            INNER JOIN clases_espacios ce ON c.id = ce.clase_id
            LEFT JOIN clases_reservas cr ON ce.id = cr.clase_espacio_id
            GROUP BY c.nombre, ce.fecha
            ORDER BY TotalReservas DESC
            LIMIT 8";

                using (var command = new MySqlCommand(query, connection))
                {
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var clase = reader.GetString("Clase");
                            var horario = reader.GetDateTime("Horario").ToString("yyyy-MM-dd HH:mm");
                            var reservas = reader.GetInt32("TotalReservas");
                            resultados.Add((clase, horario, reservas));
                        }
                    }
                }
            }

            return resultados;
        }
    }
}

