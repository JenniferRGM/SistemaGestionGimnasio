using MySql.Data.MySqlClient;
using ProyectoBlazor.Models;
using ProyectoBlazor.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using static iText.StyledXmlParser.Jsoup.Select.Evaluator;


public class FacturaRepository
{
    /// <summary>
    /// Repositorio para gestionar operaciones relacionadas con facturas en la base de datos.
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
    /// Obtiene una lista de facturas dentro de un rango de fechas.
    /// </summary>
    /// <returns>Lista de <see cref="Factura"/>.</returns>

    public async Task<List<Factura>> ObtenerFacturasPorRangoFechasAsync()
    {
        var facturas = new List<Factura>();

        using (var connection = new MySqlConnection(_connectionString))
        {
            await connection.OpenAsync();
            var query = "SELECT * FROM facturas";

            using (var command = new MySqlCommand(query, connection))
            {

                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        var factura = new Factura
                        {
                            Id = reader.GetInt32("id"),
                            NumeroFactura = reader.GetString("numero_factura"),
                            FechaEmision = reader.GetDateTime("fecha_emision"),
                            FechaVencimiento = reader.GetDateTime("fecha_vencimiento"),
                            Total = reader.GetDecimal("total"),
                            MatriculaId = reader.GetInt32("matricula_id"),
                            CreatedAt = reader.GetDateTime("created_at"),
                            UpdatedAt = reader.GetDateTime("updated_at")
                        };

                        // Obtiene los ítems de la factura
                        factura.FacturaItems = await ObtenerFacturaItemsAsync(factura.Id);
                        facturas.Add(factura);
                    }
                }
            }
        }

        return facturas;
    }


    /// <summary>
    /// Obtiene una factura por su identificador.
    /// </summary>
    /// <param name="id">Identificador único de la factura.</param>
    /// <returns>Instancia de <see cref="Factura"/> o <c>null</c> si no existe.</returns>
    public async Task<Factura> ObtenerFacturaPorIdAsync(int id)
    {
        using (var connection = new MySqlConnection(_connectionString))
        {
            await connection.OpenAsync();
            var query = "SELECT * FROM facturas WHERE id = @Id";
            using (var command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Id", id);
                using (var reader = await command.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        var factura = new Factura
                        {
                            Id = reader.GetInt32("id"),
                            NumeroFactura = reader.GetString("numero_factura"),
                            FechaEmision = reader.GetDateTime("fecha_emision"),
                            FechaVencimiento = reader.GetDateTime("fecha_vencimiento"),
                            Total = reader.GetDecimal("total"),
                            MatriculaId = reader.GetInt32("matricula_id"),
                            CreatedAt = reader.GetDateTime("created_at"),
                            UpdatedAt = reader.GetDateTime("updated_at")
                        };

                        // Obtiene los ítems de la factura
                        factura.FacturaItems = await ObtenerFacturaItemsAsync(factura.Id);
                        return factura;
                    }
                }
            }
        }

        return null;
    }

    /// <summary>
    /// Obtiene los ítems de una factura específica.
    /// </summary>
    /// <param name="facturaId">Identificador de la factura.</param>
    /// <returns>Lista de <see cref="FacturaItem"/>.</returns>
    private async Task<List<FacturaItem>> ObtenerFacturaItemsAsync(int facturaId)
    {
        var facturaItems = new List<FacturaItem>();

        using (var connection = new MySqlConnection(_connectionString))
        {
            await connection.OpenAsync();
            var query = "SELECT * FROM facturas_items WHERE factura_id = @FacturaId";
            using (var command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@FacturaId", facturaId);
                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        facturaItems.Add(new FacturaItem
                        {
                            Id = reader.GetInt32("id"),
                            FacturaId = reader.GetInt32("factura_id"),
                            Descripcion = reader.GetString("descripcion"),
                            Cantidad = reader.GetInt32("cantidad"),
                            PrecioUnitario = reader.GetDecimal("precio_unitario"),
                            TotalItem = reader.GetDecimal("total_item"),
                            CreatedAt = reader.GetDateTime("created_at"),
                            UpdatedAt = reader.GetDateTime("updated_at")
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
    /// <param name="factura">Instancia de <see cref="Factura"/> a insertar.</param>
    /// <returns>Identificador único de la factura recién creada.</returns>
    public virtual async Task<int> CrearFacturaAsync(Factura factura)
    {
        using (var connection = new MySqlConnection(_connectionString))
        {
            await connection.OpenAsync();

            var query = @"
            INSERT INTO facturas (NumeroFactura, FechaEmision, FechaVencimiento, Total, MatriculaId, CreatedAt, UpdatedAt)
            VALUES (@NumeroFactura, @FechaEmision, @FechaVencimiento, @Total, @MatriculaId, @CreatedAt, @UpdatedAt);
            SELECT LAST_INSERT_ID();";  // Esto devuelve el último ID insertado

            using (var command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@NumeroFactura", factura.NumeroFactura);
                command.Parameters.AddWithValue("@FechaEmision", factura.FechaEmision);
                command.Parameters.AddWithValue("@FechaVencimiento", factura.FechaVencimiento);
                command.Parameters.AddWithValue("@Total", factura.Total);
                command.Parameters.AddWithValue("@MatriculaId", factura.MatriculaId);
                command.Parameters.AddWithValue("@CreatedAt", factura.CreatedAt);
                command.Parameters.AddWithValue("@UpdatedAt", factura.UpdatedAt);

                // Ejecuta la consulta y obtener el último ID insertado
                int facturaId = Convert.ToInt32(await command.ExecuteScalarAsync());

                // Retorna el ID de la factura recién creada
                return facturaId;
            }
        }
    }

    public int CrearFactura(Factura factura)
    {
        using (var connection = new MySqlConnection(_connectionString))
        {
            connection.Open();  // Abre la conexión de forma sincrónica

            var query = @"
        INSERT INTO facturas (numero_factura, fecha_emision, fecha_vencimiento, total, matricula_id, created_at, updated_at)
        VALUES (@NumeroFactura, @FechaEmision, @FechaVencimiento, @Total, @MatriculaId, @CreatedAt, @UpdatedAt);
        SELECT LAST_INSERT_ID();";  // Esto devuelve el último ID insertado

            using (var command = new MySqlCommand(query, connection))
            {
                // Agrega parámetros a la consulta
                command.Parameters.AddWithValue("@NumeroFactura", factura.NumeroFactura);
                command.Parameters.AddWithValue("@FechaEmision", factura.FechaEmision);
                command.Parameters.AddWithValue("@FechaVencimiento", factura.FechaVencimiento);
                command.Parameters.AddWithValue("@Total", factura.Total);
                command.Parameters.AddWithValue("@MatriculaId", factura.MatriculaId);
                command.Parameters.AddWithValue("@CreatedAt", factura.CreatedAt);
                command.Parameters.AddWithValue("@UpdatedAt", factura.UpdatedAt);

                // Ejecuta la consulta y obtener el último ID insertado de forma sincrónica
                int facturaId = Convert.ToInt32(command.ExecuteScalar());  // Ejecuta sincrónicamente

                // Retorna el ID de la factura recién creada
                return facturaId;
            }
        }
    }


    /// <summary>
    /// Crea los ítems de una factura en la base de datos.
    /// </summary>
    /// <param name="facturaItems">Lista de <see cref="FacturaItem"/> a insertar.</param>
    public virtual async Task CrearFacturaItemsAsync(List<FacturaItem> facturaItems)
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

    public void CrearFacturaItemsSync(List<FacturaItem> facturaItems)
    {
        using (var connection = new MySqlConnection(_connectionString))
        {
            connection.Open();  // Abre la conexión de forma sincrónica

            foreach (var item in facturaItems)
            {
                var query = @"INSERT INTO facturas_items (factura_id, descripcion, cantidad, Precio_Unitario, Total_Item, Created_At, Updated_At)
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

                    command.ExecuteNonQuery();
                }
            }
        }


    }
}
