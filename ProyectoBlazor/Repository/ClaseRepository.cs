using System.Data;
using MySql.Data.MySqlClient;
using SistemaGestionGimnasio.Modelos;

namespace ProyectoBlazor.Repository
{
    /// <summary>
    /// Proporciona métodos para acceder y gestionar la información de las clases en la base de datos.
    /// </summary>
    public class ClaseRepository
    {
        /// <summary>
        /// Cadena de conexión a la base de datos MySQL.
        /// </summary>
        private readonly string _connectionString;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="ClaseRepository"/>.
        /// </summary>
        /// <param name="connectionString">Cadena de conexión a la base de datos.</param>
        public ClaseRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        /// <summary>
        /// Obtiene todas las clases asociadas a un entrenador específico.
        /// </summary>
        /// <param name="entrenadorId">Identificador del entrenador.</param>
        /// <returns>Lista de clases asociadas al entrenador.</returns>
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

        /// <summary>
        /// Obtiene todas las clases registradas en la base de datos.
        /// </summary>
        /// <returns>Lista de todas las clases.</returns>
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

        /// <summary>
        /// Obtiene la información de una clase específica por su identificador.
        /// </summary>
        /// <param name="claseId">Identificador único de la clase.</param>
        /// <returns>Objeto <see cref="ClasesModel"/> con la información de la clase o null si no se encuentra.</returns>
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
