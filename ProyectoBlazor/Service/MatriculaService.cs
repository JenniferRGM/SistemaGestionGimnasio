using ProyectoBlazor.Modelos;
using ProyectoBlazor.Models;
using ProyectoBlazor.Repository;

namespace ProyectoBlazor.Service
{
    /// <summary>
    /// Servicio para gestionar las matrículas, incluyendo la generación de facturas y membresías.
    /// </summary>
    public class MatriculaService
    {

        private MatriculaRepository matriculaRepository;
        private FacturacionService facturacionService;
        private MembresiaService membresiaService;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="MatriculaService"/>.
        /// </summary>
        /// <param name="matriculaRepository">Repositorio para gestionar matrículas.</param>
        /// <param name="facturacionService">Servicio para gestionar facturación.</param>
        /// <param name="membresiaService">Servicio para gestionar membresías.</param>
        public MatriculaService(MatriculaRepository matriculaRepository, FacturacionService facturacionService, MembresiaService membresiaService)
        {
            this.matriculaRepository = matriculaRepository;
            this.facturacionService = facturacionService;
            this.membresiaService = membresiaService;
        }

        /// <summary>
        /// Registra una nueva matrícula, genera su factura y crea una membresía asociada.
        /// </summary>
        /// <param name="planId">ID del plan asociado a la matrícula.</param>
        /// <param name="usuarioId">ID del usuario asociado a la matrícula.</param>
        /// <param name="clienteNombre">Nombre del cliente.</param>
        /// <param name="montoMatricula">Monto de la matrícula.</param>
        /// <param name="fechaMatricula">Fecha de la matrícula.</param>
        /// <param name="metodoPago">Método de pago utilizado.</param>
        /// <returns>ID de la factura generada.</returns>
        public int RegistrarMatricula(int planId, int usuarioId,
        string clienteNombre, double montoMatricula, DateOnly fechaMatricula, string metodoPago)
        {
            try
            {
                // Registra la matrícula en la base de datos
                int matriculaId = matriculaRepository.RegistrarMatricula(planId, usuarioId,
                    clienteNombre, montoMatricula, fechaMatricula, metodoPago);

                // Genera una nueva factura asociada a la matrícula
                Factura factura = new Factura
                {
                    MatriculaId = matriculaId,
                    NumeroFactura = GenerateFacturaNumber(),
                    FechaEmision = DateTime.Now,
                    FechaVencimiento = DateTime.Now.AddDays(30), // La factura vence en 30 días
                    Total = (decimal)montoMatricula,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                };

                // Crea un ítem para la factura
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

                // Registra la factura en el sistema
                int facturaId = facturacionService.CrearFacturaSync(factura, facturaItems);
                // Genera una membresía asociada a la matrícula
                membresiaService.crearMembresia(usuarioId, DateOnly.FromDateTime(DateTime.Now), DateOnly.FromDateTime(DateTime.Now.AddDays(30)));

                // Retorna el ID de la factura generada
                return facturaId;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al registrar matrícula y crear factura: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Genera un número único para la factura.
        /// </summary>
        /// <returns>Número único de factura.</returns>
        private string GenerateFacturaNumber()
        {
            return $"FAC-{DateTime.Now:yyyyMMddHHmmss}";  // Ejemplo: FAC-20241217123545
        }

    }

}
