using System.Data;
using MySql.Data.MySqlClient;
using ProyectoBlazor.Modelos;
using ProyectoBlazor.Models;

namespace ProyectoBlazor.Repository
{
    public class PlanRepository
    {

        private readonly string _connectionString;

        public PlanRepository(string connectionString)
        {
            _connectionString = connectionString;
        }


        public async Task<List<Plan>> ObtenerTodosLosPlanes()
        {
            var planes = new List<Plan>();

            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                string query = "SELECT id, nombre FROM plan"; // Especificar columnas para optimizar

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

