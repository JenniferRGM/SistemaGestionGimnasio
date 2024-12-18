using ProyectoBlazor.Modelos;
using ProyectoBlazor.Models;
using ProyectoBlazor.Repository;
using SistemaGestionGimnasio.Modelos;
using SistemaGimnasio.Repository;

namespace ProyectoBlazor.Service
{
    public class MatriculaService
    {

        private MatriculaRepository matriculaRepository;
        private FacturacionService facturacionService;
        private MembresiaService membresiaService;


        public MatriculaService(MatriculaRepository matriculaRepository, FacturacionService facturacionService, MembresiaService membresiaService)
        {
            this.matriculaRepository = matriculaRepository;
            this.facturacionService = facturacionService;
            this.membresiaService = membresiaService;
        }

        public int RegistrarMatricula(int planId, int usuarioId,
        string clienteNombre, double montoMatricula, DateOnly fechaMatricula, string metodoPago)
        {
            try
            {
                // Registrar la matrícula
                int matriculaId = matriculaRepository.RegistrarMatricula(planId, usuarioId,
                    clienteNombre, montoMatricula, fechaMatricula, metodoPago);

                // Crear la factura
                Factura factura = new Factura
                {
                    MatriculaId = matriculaId,
                    NumeroFactura = GenerateFacturaNumber(),
                    FechaEmision = DateTime.Now,
                    FechaVencimiento = DateTime.Now.AddDays(30),
                    Total = (decimal)montoMatricula,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                };

                // Crear los ítems de la factura
                List<FacturaItem> facturaItems = new List<FacturaItem>
        {
            new FacturaItem
            {
                FacturaId = factura.Id,
                Descripcion = "Matrícula",
                Cantidad = 1,
                PrecioUnitario = (decimal)montoMatricula,
                TotalItem = (decimal)montoMatricula,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            }
        };

                factura.FacturaItems = facturaItems;

                // Obtener el ID de la factura creada
                int facturaId = facturacionService.CrearFacturaSync(factura, facturaItems);

                membresiaService.crearMembresia(usuarioId, DateOnly.FromDateTime(DateTime.Now), DateOnly.FromDateTime(DateTime.Now.AddDays(30)));

                // Retornar el ID de la factura
                return facturaId;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al registrar matrícula y crear factura: {ex.Message}");
                throw;
            }
        }



        private string GenerateFacturaNumber()
        {
            return $"FAC-{DateTime.Now:yyyyMMddHHmmss}";  // Ejemplo: FAC-20241217123545
        }

    }

}
