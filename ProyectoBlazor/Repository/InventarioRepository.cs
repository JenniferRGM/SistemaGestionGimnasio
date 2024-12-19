
using System.Data;
using MySql.Data.MySqlClient;
using ProyectoBlazor.Modelos;


namespace ProyectoBlazor.Repository
{
    // <summary>
    /// Repositorio para gestionar las operaciones relacionadas con el inventario en la base de datos.
    /// </summary>
    public class InventarioRepository
    {
        /// <summary>
        /// Cadena de conexión a la base de datos MySQL.
        /// </summary>
        private readonly string _connectionString;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="InventarioRepository"/>.
        /// </summary>
        /// <param name="connectionString">Cadena de conexión a la base de datos.</param>
        public InventarioRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        /// <summary>
        /// Obtiene una lista de equipos cuyo vencimiento está próximo (dentro de los próximos 3 meses).
        /// </summary>
        /// <returns>Lista de <see cref="InventarioModel"/> con los equipos próximos a vencer.</returns>
        public async Task<List<InventarioModel>> ObtenerEquiposProximosAVencer()
        {
            List<InventarioModel> equiposProximosAVencer = new List<InventarioModel>();

            // Fecha límite: 3 meses desde la fecha actual
            DateTime fechaLimite = DateTime.Now.AddMonths(3);

            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string query = @"
                SELECT * FROM inventario 
                WHERE DATE_ADD(FechaAdquisicion, INTERVAL VidaUtilDias DAY) <= @FechaLimite
            ";

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FechaLimite", fechaLimite);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            equiposProximosAVencer.Add(new InventarioModel
                            {
                                NombreEquipo = reader.GetString("NombreEquipo"),
                                Categoria = reader.GetString("Categoria"),
                                FechaAdquisicion = reader.GetDateTime("FechaAdquisicion"),
                                VidaUtilDias = reader.GetInt32("VidaUtilDias"),
                                Estado = reader.GetString("Estado")
                            });
                        }
                    }
                }
            }

            return equiposProximosAVencer;
        }

        /// <summary>
        /// Obtiene todos los equipos del inventario.
        /// </summary>
        /// <returns>Lista de <see cref="InventarioModel"/> con todos los equipos.</returns>
        public async Task<List<InventarioModel>> ObtenerTodosLosEquipos()
        {
            List<InventarioModel> equipos = new List<InventarioModel>();

            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string query = "SELECT * FROM inventario";

                using (var command = new MySqlCommand(query, connection))
                {
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            equipos.Add(new InventarioModel
                            {
                                Id = reader.GetInt32("id"),
                                NombreEquipo = reader.GetString("NombreEquipo"),
                                Categoria = reader.GetString("Categoria"),
                                FechaAdquisicion = reader.GetDateTime("FechaAdquisicion"),
                                VidaUtilDias = reader.GetInt32("VidaUtilDias"),
                                Estado = reader.GetString("Estado")
                            });
                        }
                    }
                }
            }

            return equipos;
        }

        /// <summary>
        /// Obtiene un equipo por su identificador.
        /// </summary>
        /// <param name="id">Identificador único del equipo.</param>
        /// <returns>Instancia de <see cref="InventarioModel"/> o <c>null</c> si no existe.</returns>
        public virtual async Task<InventarioModel> ObtenerEquipoPorId(int id)
        {
            InventarioModel equipo = null;

            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string query = "SELECT * FROM inventario WHERE id = @Id";

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            equipo = new InventarioModel
                            {
                                Id = reader.GetInt32("id"),
                                NombreEquipo = reader.GetString("NombreEquipo"),
                                Categoria = reader.GetString("Categoria"),
                                FechaAdquisicion = reader.GetDateTime("FechaAdquisicion"),
                                VidaUtilDias = reader.GetInt32("VidaUtilDias"),
                                Estado = reader.GetString("Estado")
                            };
                        }
                    }
                }
            }

            return equipo;
        }

        /// <summary>
        /// Crea un nuevo equipo en el inventario.
        /// </summary>
        /// <param name="nuevoEquipo">Instancia de <see cref="InventarioModel"/> con los datos del nuevo equipo.</param>
        /// <returns>Identificador único del equipo recién creado.</returns>
        public async Task<int> CrearEquipo(InventarioModel nuevoEquipo)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string query = @"
                INSERT INTO inventario (NombreEquipo, Categoria, FechaAdquisicion, VidaUtilDias, Estado)
                VALUES (@NombreEquipo, @Categoria, @FechaAdquisicion, @VidaUtilDias, @Estado);
                SELECT LAST_INSERT_ID();";

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@NombreEquipo", nuevoEquipo.NombreEquipo);
                    command.Parameters.AddWithValue("@Categoria", nuevoEquipo.Categoria);
                    command.Parameters.AddWithValue("@FechaAdquisicion", nuevoEquipo.FechaAdquisicion);
                    command.Parameters.AddWithValue("@VidaUtilDias", nuevoEquipo.VidaUtilDias);
                    command.Parameters.AddWithValue("@Estado", nuevoEquipo.Estado);

                    return Convert.ToInt32(await command.ExecuteScalarAsync());
                }
            }
        }

        /// <summary>
        /// Actualiza los datos de un equipo existente.
        /// </summary>
        /// <param name="id">Identificador único del equipo.</param>
        /// <param name="equipoActualizado">Instancia de <see cref="InventarioModel"/> con los nuevos datos.</param>
        /// <returns><c>true</c> si la actualización fue exitosa, de lo contrario, <c>false</c>.</returns>
        public async Task<bool> ActualizarEquipo(int id, InventarioModel equipoActualizado)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string query = @"
                UPDATE inventario
                SET NombreEquipo = @NombreEquipo,
                    Categoria = @Categoria,
                    FechaAdquisicion = @FechaAdquisicion,
                    VidaUtilDias = @VidaUtilDias,
                    Estado = @Estado
                WHERE id = @Id";

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.Parameters.AddWithValue("@NombreEquipo", equipoActualizado.NombreEquipo);
                    command.Parameters.AddWithValue("@Categoria", equipoActualizado.Categoria);
                    command.Parameters.AddWithValue("@FechaAdquisicion", equipoActualizado.FechaAdquisicion);
                    command.Parameters.AddWithValue("@VidaUtilDias", equipoActualizado.VidaUtilDias);
                    command.Parameters.AddWithValue("@Estado", equipoActualizado.Estado);

                    int rowsAffected = await command.ExecuteNonQueryAsync();
                    return rowsAffected > 0;
                }
            }
        }

        /// <summary>
        /// Elimina un equipo del inventario por su identificador.
        /// </summary>
        /// <param name="id">Identificador único del equipo.</param>
        /// <returns><c>true</c> si la eliminación fue exitosa, de lo contrario, <c>false</c>.</returns>

        public async Task<bool> EliminarEquipo(int id)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string query = "DELETE FROM inventario WHERE id = @Id";

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    int rowsAffected = await command.ExecuteNonQueryAsync();
                    return rowsAffected > 0;
                }
            }
        }

    }
}
