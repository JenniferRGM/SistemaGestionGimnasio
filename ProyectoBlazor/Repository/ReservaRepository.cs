using System.Data;
using MySql.Data.MySqlClient;
using ProyectoBlazor.Components.Pages;
using ProyectoBlazor.Service;
using ProyectoBlazor.Modelos;

namespace SistemaGimnasio.Repository
{
    public class ReservaRepository
    {
        private readonly string _connectionString;
        private EspacioService espacioService;

        public ReservaRepository(string connectionString, EspacioService espacioService)
        {
            _connectionString = connectionString;
            this.espacioService = espacioService;
        }

        public async Task<bool> CrearReserva(int ClaseEspacioId, int ClienteId)
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


        public async Task<bool> RestarCupo(int ClaseEspacioId)
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

