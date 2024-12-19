using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using ProyectoBlazor.Modelos;


namespace ProyectoBlazor.Repository
{
    /// <summary>
    /// Repositorio que gestiona las operaciones CRUD de usuarios en la base de datos.
    /// </summary>
    public class UsuarioRepository
    {
        /// <summary>
        /// Cadena de conexión a la base de datos MySQL.
        /// </summary>
        private readonly string _connectionString;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="UsuarioRepository"/>.
        /// </summary>
        /// <param name="connectionString">Cadena de conexión a la base de datos.</param>
        public UsuarioRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        /// <summary>
        /// Obtiene un usuario por su identificador único.
        /// </summary>
        /// <param name="id">Identificador único del usuario.</param>
        /// <returns>Instancia de <see cref="Usuario"/> si se encuentra, de lo contrario null.</returns>
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

        /// <summary>
        /// Obtiene un usuario por su nombre de usuario.
        /// </summary>
        /// <param name="nombreUsuario">Nombre del usuario a buscar.</param>
        /// <returns>Instancia de <see cref="Usuario"/> si se encuentra, de lo contrario null.</returns>
        public virtual async Task<Usuario> obtenerUsuarioPorNombreUsuario(String nombreUsuario)
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


        /// <summary>
        /// Elimina un usuario de la base de datos por su identificador único.
        /// </summary>
        /// <param name="id">Identificador único del usuario.</param>
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


        /// <summary>
        /// Obtiene todos los usuarios de tipo "Cliente".
        /// </summary>
        /// <returns>Lista de <see cref="Usuario"/> que son clientes.</returns>
        public virtual async Task<List<Usuario>> ObtenerTodosLosClientes()
        {
            List<Usuario> usuarios = new List<Usuario>();

            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                string query = "SELECT * FROM Usuarios WHERE Tipo = @Tipo";

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Tipo", "Cliente");

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var usuario = new Usuario
                            {
                                Id = reader.GetInt32("Id"),
                                Nombre = reader.GetString("Nombre"),
                                Tipo = reader.GetString("Tipo"),
                                // Agrega otros campos según sea necesario
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
