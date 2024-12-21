using MySql.Data.MySqlClient;
using ProyectoBlazor.Service;

namespace ProyectoBlazor.Repository
{
    /// <summary>
    /// Repositorio para gestionar las operaciones relacionadas con las matrículas en la base de datos.
    /// </summary>
    public class MatriculaRepository
    {
        /// <summary>
        /// Cadena de conexión a la base de datos MySQL.
        /// </summary>
        private readonly string _connectionString;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="MatriculaRepository"/>.
        /// </summary>
        /// <param name="connectionString">Cadena de conexión a la base de datos.</param>
        public MatriculaRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        /// <summary>
        /// Registra una nueva matrícula en la base de datos.
        /// </summary>
        /// <param name="membresiaId">Identificador de la membresía asociada.</param>
        /// <param name="usuarioId">Identificador del usuario asociado.</param>
        /// <param name="clienteNombre">Nombre del cliente.</param>
        /// <param name="montoMatricula">Monto de la matrícula.</param>
        /// <param name="fechaMatricula">Fecha en la que se realiza la matrícula.</param>
        /// <param name="metodoPago">Método de pago utilizado.</param>
        /// <returns>El identificador único de la matrícula recién creada.</returns>
        public int RegistrarMatricula(int usuarioId, int membresiaId,
      string clienteNombre, double montoMatricula, DateOnly fechaMatricula, string metodoPago)
        {
            try
            {
                using (var connection = new MySqlConnection(_connectionString))
                {
                    connection.Open(); // Abre la conexión

                    // Consulta para insertar los datos
                    string queryInsert = @"
                INSERT INTO matriculas 
                (cliente_id, membresia_id, cliente_nombre, monto_matricula, fecha_matricula, metodo_pago) 
                VALUES 
                (@UsuarioId, @MembresiaId, @ClienteNombre, @MontoMatricula, @FechaMatricula, @MetodoPago);";

                    using (var command = new MySqlCommand(queryInsert, connection))
                    {
                        // Convertir DateOnly a DateTime para compatibilidad con MySQL
                        var fechaMatriculaDateTime = fechaMatricula.ToDateTime(TimeOnly.MinValue);

                        // Agrega parámetros a la consulta
                        command.Parameters.AddWithValue("@UsuarioId", usuarioId);
                        command.Parameters.AddWithValue("@MembresiaId", membresiaId);
                        command.Parameters.AddWithValue("@ClienteNombre", clienteNombre);
                        command.Parameters.AddWithValue("@MontoMatricula", montoMatricula);
                        command.Parameters.AddWithValue("@FechaMatricula", fechaMatriculaDateTime);
                        command.Parameters.AddWithValue("@MetodoPago", metodoPago);

                        // Ejecuta la consulta de inserción
                        command.ExecuteNonQuery();
                    }

                    // Consulta para obtener el último ID insertado
                    string querySelect = "SELECT LAST_INSERT_ID();";

                    using (var commandSelect = new MySqlCommand(querySelect, connection))
                    {
                        // Devuelve el ID generado
                        return Convert.ToInt32(commandSelect.ExecuteScalar());
                    }
                }
            }
            catch (MySqlException ex)
            {
                // Manejo específico de errores de MySQL
                Console.WriteLine($"Error de MySQL: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                // Manejo genérico de errores
                Console.WriteLine($"Ocurrió un error: {ex.Message}");
                throw;
            }
        }

    }
}
