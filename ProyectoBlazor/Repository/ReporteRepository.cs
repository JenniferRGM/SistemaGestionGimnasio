using System.Data;
using MySql.Data.MySqlClient;

namespace SistemaGimnasio.Repository
{
    /// <summary>
    /// Repositorio que proporciona métodos para generar reportes de crecimiento de matrículas, informes contables y clases más reservadas.
    /// </summary>
    public class ReporteRepository
    {
        /// <summary>
        /// Cadena de conexión a la base de datos MySQL.
        /// </summary>
        private readonly string _connectionString;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="ReporteRepository"/>.
        /// </summary>
        /// <param name="connectionString">Cadena de conexión a la base de datos.</param>
        public ReporteRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        /// <summary>
        /// Obtiene el crecimiento de matrículas agrupado por mes, incluyendo el total acumulado.
        /// </summary>
        /// <returns>Una lista de tuplas con Fecha, Nuevas Matrículas y Total de Matrículas acumuladas.</returns>
        public async Task<List<(DateTime Fecha, int NuevasMatriculas, int TotalMatriculas)>> ObtenerCrecimientoMatriculasAsync()
        {
            var resultados = new List<(DateTime Fecha, int NuevasMatriculas, int TotalMatriculas)>();

            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                // Consulta SQL que obtiene el conteo de matrículas por mes/año
                var query = @"
            SELECT 
                DATE_FORMAT(fecha_matricula, '%Y-%m-01') AS Fecha, 
                COUNT(*) AS NuevasMatriculas
            FROM matriculas
            GROUP BY DATE_FORMAT(fecha_matricula, '%Y-%m')
            ORDER BY Fecha";

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
        /// Obtiene un informe contable que agrupa ingresos y gastos por fecha dentro de un rango específico.
        /// </summary>
        /// <param name="inicio">Fecha de inicio del rango.</param>
        /// <param name="fin">Fecha de fin del rango.</param>
        /// <returns>Una lista de tuplas con Fecha, Ingreso y Gasto.</returns>
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
        /// Obtiene una lista de las clases más reservadas, limitando a las 8 principales.
        /// </summary>
        /// <returns>Una lista de tuplas con el nombre de la clase, horario y número total de reservas.</returns>
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
