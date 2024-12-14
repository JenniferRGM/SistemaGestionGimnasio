namespace SistemaGimnasio.Repository
{
    public class EntrenadorRepository
    {
        private readonly string _connectionString;

        public EntrenadorRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
    }
}
