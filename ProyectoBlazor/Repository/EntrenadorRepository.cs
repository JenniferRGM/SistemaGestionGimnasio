namespace SistemaGimnasio.Repository
{
    /// <summary>
    /// Proporciona métodos para acceder y gestionar la información de los entrenadores en la base de datos.
    /// </summary>
    public class EntrenadorRepository
    {
        /// <summary>
        /// Cadena de conexión a la base de datos.
        /// </summary>
        private readonly string _connectionString;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="EntrenadorRepository"/>.
        /// </summary>
        /// <param name="connectionString">Cadena de conexión a la base de datos.</param>
        public EntrenadorRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
    }
}
