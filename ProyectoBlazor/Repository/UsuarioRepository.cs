using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using ProyectoBlazor.Modelos;
using SistemaGestionGimnasio.Modelos;

namespace ProyectoBlazor.Repository
{
    public class UsuarioRepository
    {
        private readonly string _connectionString;

        public UsuarioRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<Usuario> ObtenerUsuarioPorIdAsync(int id)
        {
            Usuario usuario = null;

            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                string query = "SELECT * FROM Usuarios WHERE ID = @ID";

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID", id);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            usuario = new Usuario(
                            reader.GetInt32("ID"),
                            reader.GetString("Nombre"),
                            reader.GetString("Correo"),
                            reader.GetString("Tipo"),
                            reader.GetString("Usuario"),
                            reader.GetString("Contraseña")
 );
                        }
                    }
                }
            }

            return usuario;
        }

        public async Task<Usuario> obtenerUsuarioPorNombreUsuario(String nombreUsuario)
        {
            Usuario usuario = null;

            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                string query = "SELECT * FROM Usuarios WHERE Usuario = @Usuario";

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Usuario", nombreUsuario);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            usuario = new Usuario(
                            reader.GetInt32("ID"),
                            reader.GetString("Nombre"),
                            reader.GetString("Correo"),
                            reader.GetString("Tipo"),
                            reader.GetString("Usuario"),
                            reader.GetString("Contraseña")
 );
                        }
                    }
                }
            }

            return usuario;
        }


        // Eliminar un usuario
        public async Task EliminarUsuarioAsync(int id)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                string query = "DELETE FROM Usuarios WHERE ID = @ID";

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID", id);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }
    }
}
