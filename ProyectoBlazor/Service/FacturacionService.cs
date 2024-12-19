using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProyectoBlazor.Models;
using ProyectoBlazor.Modelos;

namespace ProyectoBlazor.Service
{
    /// <summary>
    /// Servicio para gestionar la facturación en el sistema.
    /// </summary>
    public class FacturacionService
    {
        private readonly FacturaRepository _facturaRepository;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="FacturacionService"/>.
        /// </summary>
        /// <param name="facturaRepository">Repositorio de facturas.</param>
        public FacturacionService(FacturaRepository facturaRepository, MembresiaService membresiaService)
        {
            _facturaRepository = facturaRepository;
        }

        /// <summary>
        /// Obtiene una factura por su identificador único.
        /// </summary>
        /// <param name="id">Identificador de la factura.</param>
        /// <returns>Instancia de <see cref="Factura"/> si se encuentra, de lo contrario se lanza una excepción.</returns>
        public async Task<Factura> ObtenerFacturaPorIdAsync(int id)
        {
            try
            {
                return await _facturaRepository.ObtenerFacturaPorIdAsync(id);
            }
            catch (Exception ex)
            {
                // Manejo de excepciones o logging
                throw new Exception("Error al obtener la factura", ex);
            }
        }

        /// <summary>
        /// Crea una nueva factura de manera asíncrona.
        /// </summary>
        /// <param name="factura">Datos de la factura a crear.</param>
        /// <param name="facturaItems">Lista de ítems asociados a la factura.</param>
        /// <returns>Identificador de la factura creada.</returns>
        public async Task<int> CrearFacturaAsync(Factura factura, List<FacturaItem> facturaItems)
        {
            try
            {
                int idFactura = await _facturaRepository.CrearFacturaAsync(factura);

                foreach (var item in facturaItems)
                {
                    item.FacturaId = idFactura;
                }

                await _facturaRepository.CrearFacturaItemsAsync(facturaItems);

                return idFactura;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al crear la factura", ex);
            }
        }

        /// <summary>
        /// Crea una nueva factura de manera sincrónica.
        /// </summary>
        /// <param name="factura">Datos de la factura a crear.</param>
        /// <param name="facturaItems">Lista de ítems asociados a la factura.</param>
        /// <returns>Identificador de la factura creada.</returns>
        public int CrearFacturaSync(Factura factura, List<FacturaItem> facturaItems)
        {
            try
            {
                int idFactura = _facturaRepository.CrearFactura(factura);

                foreach (var item in facturaItems)
                {
                    item.FacturaId = idFactura;
                }

                _facturaRepository.CrearFacturaItemsSync(facturaItems);

                return idFactura;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al crear la factura", ex);
            }
        }

        /// <summary>
        /// Crea una factura asociada a una matrícula.
        /// </summary>
        /// <param name="matriculaId">Identificador de la matrícula.</param>
        /// <param name="fechaRegistro">Fecha de registro de la factura.</param>
        /// <param name="monto">Monto total de la factura.</param>
        public async Task CrearFacturaMatriculaAsync(int matriculaId, DateTime fechaRegistro, decimal monto)
        {
            try
            {
                var nuevaFactura = new Factura
                {
                    MatriculaId = matriculaId,
                    FechaEmision = fechaRegistro,
                    Total = monto,
                    FechaVencimiento = fechaRegistro.AddMonths(1) // Suponiendo que la factura vence en un mes
                };

                // Crea los ítems de la factura (si es necesario)
                var facturaItems = new List<FacturaItem>
            {
                new FacturaItem
                {
                    Descripcion = "Matrícula",
                    PrecioUnitario = monto,
                    FacturaId = nuevaFactura.Id
                }
            };

                // Inserta la factura y sus ítems en la base de datos
                await _facturaRepository.CrearFacturaAsync(nuevaFactura);
                await _facturaRepository.CrearFacturaItemsAsync(facturaItems);
            }
            catch (Exception ex)
            {
                // Manejo de excepciones o logging
                throw new Exception("Error al crear la factura de matrícula", ex);
            }
        }

        /// <summary>
        /// Obtiene todas las facturas en un rango de fechas.
        /// </summary>
        /// <returns>Lista de facturas.</returns>
        public async Task<List<Factura>> ObtenerFacturasPorRangoFechasAsync()
        {
            try
            {
                var facturas = new List<Factura>();
                facturas = await _facturaRepository.ObtenerFacturasPorRangoFechasAsync();
                return facturas;
            }
            catch (Exception ex)
            {
                // Manejo de excepciones o logging
                throw new Exception("Error al obtener las facturas por rango de fechas", ex);
            }
        }
    }

}

