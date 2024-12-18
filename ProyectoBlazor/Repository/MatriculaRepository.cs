using MySql.Data.MySqlClient;
using ProyectoBlazor.Service;

namespace ProyectoBlazor.Repository
{
    public class MatriculaRepository
    {

        private readonly string _connectionString;


        public MatriculaRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

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
                    // Agregar parámetros a la consulta
                    command.Parameters.AddWithValue("@MembresiaId", membresiaId);
                    command.Parameters.AddWithValue("@UsuarioId", usuarioId);
                    command.Parameters.AddWithValue("@ClienteNombre", clienteNombre);
                    command.Parameters.AddWithValue("@MontoMatricula", montoMatricula);
                    command.Parameters.AddWithValue("@FechaMatricula", fechaMatricula);
                    command.Parameters.AddWithValue("@MetodoPago", metodoPago);

                    // Ejecutar la consulta y obtener el ID generado de forma sincrónica
                    var result = command.ExecuteScalar();

                    // Retornar el ID de la matrícula creada
                    return Convert.ToInt32(result);
                }
            }
        }






    }
}
