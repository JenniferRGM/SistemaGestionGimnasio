using System.Data;
using MySql.Data.MySqlClient;
using ProyectoBlazor.Modelos;
using ProyectoBlazor.Models;

namespace ProyectoBlazor.Repository
{
    /// <summary>
    /// Repositorio para gestionar las operaciones relacionadas con los planes en la base de datos.
    /// </summary>
    public class PlanRepository
    {
        /// <summary>
        /// Cadena de conexión a la base de datos MySQL.
        /// </summary>
        private readonly string _connectionString;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="PlanRepository"/>.
        /// </summary>
        /// <param name="connectionString">Cadena de conexión a la base de datos.</param>
        public PlanRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        /// <summary>
        /// Obtiene todos los planes registrados en la base de datos.
        /// </summary>
        /// <returns>Lista de <see cref="Plan"/> con los datos de todos los planes.</returns>
        public virtual async Task<List<Plan>> ObtenerTodosLosPlanes()
        {
            var planes = new List<Plan>();

            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                string query = "SELECT id, nombre FROM plan"; 

                using (var command = new MySqlCommand(query, connection))
                {
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var plan = new Plan(reader.GetInt32("id"), reader.GetString("nombre"));
                            planes.Add(plan);
                        }
                    }
                }
            }
            return planes;
        }

    }


}

