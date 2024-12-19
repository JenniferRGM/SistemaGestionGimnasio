using System.Data;
using MySql.Data.MySqlClient;
using ProyectoBlazor.Components.Pages;
using ProyectoBlazor.Service;
using ProyectoBlazor.Modelos;

namespace SistemaGimnasio.Repository
{
    /// <summary>
    /// Repositorio para gestionar las reservas de clases en el sistema.
    /// </summary>
    public class ReservaRepository
    {
        /// <summary>
        /// Cadena de conexión a la base de datos MySQL.
        /// </summary>
        private readonly string _connectionString;

        /// <summary>
        /// Servicio para gestionar espacios relacionados con reservas.
        /// </summary>
        private EspacioService espacioService;


        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="ReservaRepository"/>.
        /// </summary>
        /// <param name="connectionString">Cadena de conexión a la base de datos.</param>
        /// <param name="espacioService">Servicio para gestionar espacios.</param>
        public ReservaRepository(string connectionString, EspacioService espacioService)
        {
            _connectionString = connectionString;
            this.espacioService = espacioService;
        }

        /// <summary>
        /// Crea una nueva reserva para un cliente en un espacio de clase.
        /// </summary>
        /// <param name="ClaseEspacioId">Identificador del espacio de clase.</param>
        /// <param name="ClienteId">Identificador del cliente.</param>
        /// <returns>Indica si la reserva fue creada exitosamente.</returns>
        public virtual async Task<bool> CrearReserva(int ClaseEspacioId, int ClienteId)
        {
            // Primero verificamos si hay cupos disponibles
            bool hayDisponibilidad = await ComprobarDisponibilidad(ClaseEspacioId);

            if (hayDisponibilidad)
            {
                // Si hay cupos disponibles, procedemos a crear la reserva
                using (var connection = new MySqlConnection(_connectionString))
                {
                    await connection.OpenAsync();

                    string query = "INSERT INTO clases_reservas (clase_espacio_id, cliente_id) VALUES (@clase_espacio_id, @cliente_id)";

                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@clase_espacio_id", ClaseEspacioId);
                        command.Parameters.AddWithValue("@cliente_id", ClienteId);

                        await command.ExecuteNonQueryAsync();
                    }
                }

                return true; // Reserva exitosa
            }

            // Si no hay cupos disponibles, retornamos false
            return false;
        }

        /// <summary>
        /// Verifica la disponibilidad de cupos en un espacio de clase.
        /// </summary>
        /// <param name="ClaseEspacioId">Identificador del espacio de clase.</param>
        /// <returns>Indica si hay disponibilidad de cupos.</returns>
        public async Task<bool> ComprobarDisponibilidad(int ClaseEspacioId)
        {
            bool hayDisponibilidad = false;

            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                // Primero verificamos los cupos disponibles
                string checkQuery = "SELECT cupos FROM clases_espacios WHERE id = @id";

                using (var checkCommand = new MySqlCommand(checkQuery, connection))
                {
                    checkCommand.Parameters.AddWithValue("@id", ClaseEspacioId);

                    var result = await checkCommand.ExecuteScalarAsync();

                    if (result != null && int.TryParse(result.ToString(), out int cuposDisponibles) && cuposDisponibles > 0)
                    {
                        // Si hay cupos disponibles, los decrementamos
                        hayDisponibilidad = true;

                        string updateQuery = "UPDATE clases_espacios SET cupos = cupos - 1 WHERE id = @id";

                        using (var updateCommand = new MySqlCommand(updateQuery, connection))
                        {
                            updateCommand.Parameters.AddWithValue("@id", ClaseEspacioId);
                            await updateCommand.ExecuteNonQueryAsync();
                        }
                    }
                }
            }

            return hayDisponibilidad;
        }

        /// <summary>
        /// Resta un cupo disponible en un espacio de clase.
        /// </summary>
        /// <param name="ClaseEspacioId">Identificador del espacio de clase.</param>
        /// <returns>Indica si la operación fue exitosa.</returns>
        public virtual async Task<bool> RestarCupo(int ClaseEspacioId)
        {
            bool exito = false;

            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                // Primero verificamos si hay cupos disponibles
                string checkQuery = "SELECT cupos FROM clases_espacios WHERE id = @id";

                using (var checkCommand = new MySqlCommand(checkQuery, connection))
                {
                    checkCommand.Parameters.AddWithValue("@id", ClaseEspacioId);

                    var result = await checkCommand.ExecuteScalarAsync();

                    if (result != null && int.TryParse(result.ToString(), out int cuposDisponibles) && cuposDisponibles > 0)
                    {
                        // Si hay cupos disponibles, se restan
                        string updateQuery = "UPDATE clases_espacios SET cupos = cupos - 1 WHERE id = @id";

                        using (var updateCommand = new MySqlCommand(updateQuery, connection))
                        {
                            updateCommand.Parameters.AddWithValue("@id", ClaseEspacioId);
                            await updateCommand.ExecuteNonQueryAsync();
                            exito = true; // Operación exitosa
                        }
                    }
                }
            }

            return exito;
        }

        /// <summary>
        /// Obtiene todas las reservas realizadas por un cliente.
        /// </summary>
        /// <param name="ClienteId">Identificador del cliente.</param>
        /// <returns>Lista de reservas realizadas por el cliente.</returns>
        public async Task<List<Reservas>> ObtenerReservasPorClienteId(Int32 ClienteId)
        {
            List<Reservas> reservas = new List<Reservas>();

            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                string query = "SELECT * FROM clases_reservas WHERE cliente_id = @ClienteId";

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ClienteId", ClienteId);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        // Iteramos por todas las filas que hemos recuperado
                        while (await reader.ReadAsync())
                        {
                            var reserva = new Reservas(reader.GetInt32("id"),
                            reader.GetInt32("clase_espacio_id"),
                            reader.GetInt32("cliente_id")
);

                            reserva.espacio = await espacioService.ObtenerEspacioPorId(reserva.ClaseEspacioId);

                            reservas.Add(reserva);
                        }
                    }
                }
            }

            return reservas;
        }

    }
}

