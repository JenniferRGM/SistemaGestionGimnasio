using System.Data;
using MySql.Data.MySqlClient;
using SistemaGestionGimnasio.Modelos;

namespace ProyectoBlazor.Repository
{
    public class ClaseRepository
    {

        private readonly string _connectionString;

        public ClaseRepository(string connectionString)
        {
            _connectionString = connectionString;
        }


        public async Task<List<ClasesModel>> ObtenerTodasLasClasesPorEntrenador(Int32 EntrenadorId)
        {
            List<ClasesModel> clases = new List<ClasesModel>();

            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                string query = "SELECT c.*, e.nombre as entrenador_nombre FROM clases c INNER JOIN entrenadores e ON c.entrenador_id = e.id  WHERE c.entrenador_id = @EntrenadorId";

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@EntrenadorId", EntrenadorId);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var clase = new ClasesModel(
                                reader.GetInt32("ID"),
                                reader.GetString("Nombre"),
                                reader.GetInt32("entrenador_id"),
                                reader.GetString("entrenador_nombre")
                            );

                            clases.Add(clase);
                        }
                    }
                }
            }

            return clases;
        }

        public async Task<List<ClasesModel>> ObtenerTodasLasClases()
        {
            List<ClasesModel> clases = new List<ClasesModel>();

            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                string query = "SELECT c.*, e.nombre as entrenador_nombre FROM clases c INNER JOIN entrenadores e ON c.entrenador_id = e.id  ";

                using (var command = new MySqlCommand(query, connection))
                {

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var clase = new ClasesModel(
                                reader.GetInt32("ID"),
                                reader.GetString("Nombre"),
                                reader.GetInt32("entrenador_id"),
                                reader.GetString("entrenador_nombre")
                            );

                            clases.Add(clase);
                        }
                    }
                }
            }

            return clases;
        }

        public async Task<ClasesModel> ObtenerClasePorId(Int32 ClaseId)
        {
            ClasesModel clase = null;

            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                string query = "SELECT c.*, e.nombre as entrenador_nombre FROM clases c INNER JOIN entrenadores e ON c.entrenador_id = e.id WHERE c.id = @claseId LIMIT 1";

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@claseId", ClaseId);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            clase = new ClasesModel(
                                reader.GetInt32("ID"),
                                reader.GetString("Nombre"),
                                reader.GetInt32("entrenador_id"),
                                reader.GetString("entrenador_nombre")
                            );
                        }
                    }
                }
            }

            return clase;
        }




    }


}
