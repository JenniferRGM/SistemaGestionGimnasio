using ProyectoBlazor.Repository;

namespace ProyectoBlazor.Service
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using ProyectoBlazor.Models;
    using ProyectoBlazor.Modelos;
    using SistemaGestionGimnasio.Modelos;

    public class FacturacionService
    {
        private readonly FacturaRepository _facturaRepository;

        public FacturacionService(FacturaRepository facturaRepository, MembresiaService membresiaService)
        {
            _facturaRepository = facturaRepository;
        }




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

                // Crear los ítems de la factura (si es necesario)
                var facturaItems = new List<FacturaItem>
            {
                new FacturaItem
                {
                    Descripcion = "Matrícula",
                    PrecioUnitario = monto,
                    FacturaId = nuevaFactura.Id
                }
            };

                // Insertar la factura y sus ítems en la base de datos
                await _facturaRepository.CrearFacturaAsync(nuevaFactura);
                await _facturaRepository.CrearFacturaItemsAsync(facturaItems);
            }
            catch (Exception ex)
            {
                // Manejo de excepciones o logging
                throw new Exception("Error al crear la factura de matrícula", ex);
            }
        }

        // Obtener todas las facturas en un rango de fechas
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

