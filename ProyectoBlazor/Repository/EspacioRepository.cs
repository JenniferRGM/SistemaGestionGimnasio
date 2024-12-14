using System.Data;
using MySql.Data.MySqlClient;
using ProyectoBlazor.Modelos;
using ProyectoBlazor.Models;
using SistemaGestionGimnasio.Modelos;

namespace ProyectoBlazor.Repository
{
    public class EspacioRepository
    {
        private readonly string _connectionString;


        public EspacioRepository(string connectionString)
        {
            _connectionString = connectionString;
        }



        public async Task CrearEspacio(int claseId, DateTime fecha, int cupos)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                string query = "INSERT INTO clases_espacios (clase_id, fecha, cupos) VALUES (@claseId, @fecha, @cupos)";

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@claseId", claseId);
                    command.Parameters.AddWithValue("@fecha", fecha);
                    command.Parameters.AddWithValue("@cupos", cupos);

                    // Ejecuta el comando y retorna el número de filas afectadas.
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task<List<EspacioModel>> ListarEspaciosPorClaseId(int ClaseId)
        {
            List<EspacioModel> espacios = new List<EspacioModel>();

            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                string query = "SELECT ce.*, c.nombre as clase_nombre FROM clases_espacios ce INNER JOIN clases c ON ce.id = c.id WHERE clase_id = @ClaseId";

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ClaseId", ClaseId);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var espacio = new EspacioModel(
                                reader.GetInt32("id"),
                                reader.GetInt32("clase_id"),
                                reader.GetDateTime("fecha"),
                                reader.GetString("clase_nombre"),
                               reader.GetInt32("cupos")
                            );

                            espacios.Add(espacio);
                        }
                    }
                }
            }

            return espacios;
        }

        public async Task<EspacioModel> ObtenerEspacioPorId(Int32 EspacioId)
        {
            EspacioModel espacio = null;

            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                string query = "SELECT ce.*, c.nombre as clase_nombre FROM clases_espacios ce INNER JOIN clases c ON ce.id = c.id WHERE ce.id = @EspacioId";

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@EspacioId", EspacioId);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            espacio = new EspacioModel(
                               reader.GetInt32("id"),
                               reader.GetInt32("clase_id"),
                               reader.GetDateTime("fecha"),
                               reader.GetString("clase_nombre"),
                              reader.GetInt32("cupos")
                           );

                        }
                    }
                }
            }

            return espacio;
        }


        public async Task<List<Usuario>> ConsultarPersonasEnEspacioPorEspacioId(int EspacioId)
        {
            var usuarios = new List<Usuario>();

            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                var query = @"
                SELECT u.id, u.nombre, u.correo as email, u.telefono
                FROM usuarios u
                JOIN clases_reservas cr ON u.id = cr.cliente_id
                JOIN clases_espacios ce ON cr.clase_espacio_id = ce.id
                WHERE ce.id = @EspacioId";

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@EspacioId", EspacioId);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var usuario = new Usuario
                            {
                                Id = reader.GetInt32("id"),
                                Nombre = reader.GetString("nombre"),
                                Correo = reader.GetString("email"),
                            };
                            usuarios.Add(usuario);
                        }
                    }
                }
            }

            return usuarios;
        }


    }
}
