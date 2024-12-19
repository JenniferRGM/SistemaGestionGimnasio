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
        public int RegistrarMatricula(int membresiaId, int usuarioId,
            string clienteNombre, double montoMatricula, DateOnly fechaMatricula, string metodoPago)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();  // Abre la conexión de forma sincrónica

                string query = @"
        INSERT INTO matriculas 
        (membresia_id, cliente_id, cliente_nombre, monto_matricula, fecha_matricula, metodo_pago) 
        VALUES 
        (@MembresiaId, @UsuarioId, @ClienteNombre, @MontoMatricula, @FechaMatricula, @MetodoPago);
        SELECT LAST_INSERT_ID();"; // Obtener el último ID insertado

                using (var command = new MySqlCommand(query, connection))
                {
                    // Agrega parámetros a la consulta
                    command.Parameters.AddWithValue("@MembresiaId", membresiaId);
                    command.Parameters.AddWithValue("@UsuarioId", usuarioId);
                    command.Parameters.AddWithValue("@ClienteNombre", clienteNombre);
                    command.Parameters.AddWithValue("@MontoMatricula", montoMatricula);
                    command.Parameters.AddWithValue("@FechaMatricula", fechaMatricula);
                    command.Parameters.AddWithValue("@MetodoPago", metodoPago);

                    // Ejecuta la consulta y obtener el ID generado de forma sincrónica
                    var result = command.ExecuteScalar();

                    // Retorna el ID de la matrícula creada
                    return Convert.ToInt32(result);
                }
            }
        }

    }
}
