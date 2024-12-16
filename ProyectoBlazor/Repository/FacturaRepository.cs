using MySql.Data.MySqlClient;
using ProyectoBlazor.Models;
using SistemaGestionGimnasio.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace ProyectoBlazor.Repository
{
    /// <summary>
    /// Repositorio que gestiona las operaciones CRUD de facturas y sus ítems en la base de datos.
    /// </summary>
    public class FacturaRepository
    {
        /// <summary>
        /// Cadena de conexión a la base de datos MySQL.
        /// </summary>
        private readonly string _connectionString;


        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="FacturaRepository"/>.
        /// </summary>
        /// <param name="connectionString">Cadena de conexión a la base de datos.</param>
        public FacturaRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        /// <summary>
        /// Obtiene una factura por su identificador único, incluyendo los ítems relacionados.
        /// </summary>
        /// <param name="id">Identificador único de la factura.</param>
        /// <returns>Objeto <see cref="Factura"/> con los datos de la factura.</returns>
        public async Task<Factura> ObtenerFacturaPorIdAsync(int id)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var query = "SELECT * FROM facturas WHERE Id = @Id";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            var factura = new Factura
                            {
                                Id = reader.GetInt32("Id"),
                                NumeroFactura = reader.GetString("NumeroFactura"),
                                FechaEmision = reader.GetDateTime("FechaEmision"),
                                FechaVencimiento = reader.GetDateTime("FechaVencimiento"),
                                Total = reader.GetDecimal("Total"),
                                MatriculaId = reader.GetInt32("MatriculaId"),
                                CreatedAt = reader.GetDateTime("CreatedAt"),
                                UpdatedAt = reader.GetDateTime("UpdatedAt")
                            };

                            // Obtener los ítems de la factura
                            factura.FacturaItems = await ObtenerFacturaItemsAsync(factura.Id);
                            return factura;
                        }
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Obtiene los ítems asociados a una factura específica.
        /// </summary>
        /// <param name="facturaId">Identificador único de la factura.</param>
        /// <returns>Lista de <see cref="FacturaItem"/> asociados a la factura.</returns>
        private async Task<List<FacturaItem>> ObtenerFacturaItemsAsync(int facturaId)
        {
            var facturaItems = new List<FacturaItem>();

            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var query = "SELECT * FROM facturas_items WHERE FacturaId = @FacturaId";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FacturaId", facturaId);
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            facturaItems.Add(new FacturaItem
                            {
                                Id = reader.GetInt32("Id"),
                                FacturaId = reader.GetInt32("FacturaId"),
                                Descripcion = reader.GetString("Descripcion"),
                                Cantidad = reader.GetInt32("Cantidad"),
                                PrecioUnitario = reader.GetDecimal("PrecioUnitario"),
                                TotalItem = reader.GetDecimal("TotalItem"),
                                CreatedAt = reader.GetDateTime("CreatedAt"),
                                UpdatedAt = reader.GetDateTime("UpdatedAt")
                            });
                        }
                    }
                }
            }

            return facturaItems;
        }

        /// <summary>
        /// Crea una nueva factura en la base de datos.
        /// </summary>
        /// <param name="factura">Objeto <see cref="Factura"/> con los datos de la factura a crear.</param>
       
        public async Task CrearFacturaAsync(Factura factura)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var query = @"INSERT INTO facturas (NumeroFactura, FechaEmision, FechaVencimiento, Total, MatriculaId, CreatedAt, UpdatedAt)
                          VALUES (@NumeroFactura, @FechaEmision, @FechaVencimiento, @Total, @MatriculaId, @CreatedAt, @UpdatedAt)";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@NumeroFactura", factura.NumeroFactura);
                    command.Parameters.AddWithValue("@FechaEmision", factura.FechaEmision);
                    command.Parameters.AddWithValue("@FechaVencimiento", factura.FechaVencimiento);
                    command.Parameters.AddWithValue("@Total", factura.Total);
                    command.Parameters.AddWithValue("@MatriculaId", factura.MatriculaId);
                    command.Parameters.AddWithValue("@CreatedAt", factura.CreatedAt);
                    command.Parameters.AddWithValue("@UpdatedAt", factura.UpdatedAt);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        /// <summary>
        /// Crea una lista de ítems asociados a una factura específica.
        /// </summary>
        /// <param name="facturaItems">Lista de <see cref="FacturaItem"/> a insertar.</param>
        public async Task CrearFacturaItemsAsync(List<FacturaItem> facturaItems)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                foreach (var item in facturaItems)
                {
                    var query = @"INSERT INTO facturas_items (FacturaId, Descripcion, Cantidad, PrecioUnitario, TotalItem, CreatedAt, UpdatedAt)
                              VALUES (@FacturaId, @Descripcion, @Cantidad, @PrecioUnitario, @TotalItem, @CreatedAt, @UpdatedAt)";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@FacturaId", item.FacturaId);
                        command.Parameters.AddWithValue("@Descripcion", item.Descripcion);
                        command.Parameters.AddWithValue("@Cantidad", item.Cantidad);
                        command.Parameters.AddWithValue("@PrecioUnitario", item.PrecioUnitario);
                        command.Parameters.AddWithValue("@TotalItem", item.TotalItem);
                        command.Parameters.AddWithValue("@CreatedAt", item.CreatedAt);
                        command.Parameters.AddWithValue("@UpdatedAt", item.UpdatedAt);

                        await command.ExecuteNonQueryAsync();
                    }
                }
            }
        }
    }
}
