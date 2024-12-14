
using System.Data;
using MySql.Data.MySqlClient;
using ProyectoBlazor.Modelos;
using SistemaGestionGimnasio.Modelos;

namespace ProyectoBlazor.Repository
{
    public class InventarioRepository
    {

        private readonly string _connectionString;

        public InventarioRepository(string connectionString)
        {
            _connectionString = connectionString;
        }


        public async Task<List<InventarioModel>> ObtenerEquiposProximosAVencer()
        {
            List<InventarioModel> equiposProximosAVencer = new List<InventarioModel>();

            // Fecha límite: 3 meses desde la fecha actual
            DateTime fechaLimite = DateTime.Now.AddMonths(3);

            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string query = @"
                SELECT * FROM inventario 
                WHERE DATE_ADD(FechaAdquisicion, INTERVAL VidaUtilDias DAY) <= @FechaLimite
            ";

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FechaLimite", fechaLimite);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            equiposProximosAVencer.Add(new InventarioModel
                            {
                                NombreEquipo = reader.GetString("NombreEquipo"),
                                Categoria = reader.GetString("Categoria"),
                                FechaAdquisicion = reader.GetDateTime("FechaAdquisicion"),
                                VidaUtilDias = reader.GetInt32("VidaUtilDias"),
                                Estado = reader.GetString("Estado")
                            });
                        }
                    }
                }
            }

            return equiposProximosAVencer;
        }

    }
}
