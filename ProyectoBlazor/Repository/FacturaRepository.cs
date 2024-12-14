using MySql.Data.MySqlClient;
using ProyectoBlazor.Models;
using SistemaGestionGimnasio.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

public class FacturaRepository
{
    private readonly string _connectionString;

    // Constructor
    public FacturaRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    // Obtener una factura por su ID
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

    // Obtener los ítems de una factura
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

    // Crear una nueva factura
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

    // Crear los ítems de la factura
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
