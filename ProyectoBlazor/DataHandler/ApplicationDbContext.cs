using Microsoft.EntityFrameworkCore;
using ProyectoBlazor.Modelos;
using ProyectoBlazor.Models;
using SistemaGestionGimnasio.Modelos;

namespace ProyectoBlazor.DataHandler
{
    /// <summary>
    /// Contexto de la base de datos para la aplicación.
    /// Gestiona las conexiones y mapeos de entidades a tablas en la base de datos.
    /// </summary>
    public class ApplicationDbContext : DbContext
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="ApplicationDbContext"/>.
        /// </summary>
        /// <param name="options">Opciones de configuración del contexto de la base de datos.</param>
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // DbSets para cada tabla de la base de datos
        public DbSet<Actividad> Actividades { get; set; }
        public DbSet<Clase> Clases { get; set; }
        public DbSet<ClaseEspacio> ClasesEspacios { get; set; }
        public DbSet<ClaseReserva> ClasesReservas { get; set; }
        public DbSet<Egreso> Egresos { get; set; }
        public DbSet<Entrenador> Entrenadores { get; set; }
        public DbSet<Factura> Facturas { get; set; }
        public DbSet<FacturaItem> FacturasItems { get; set; }
        public DbSet<InformeContable> InformeContable { get; set; }
        public DbSet<Ingreso> Ingresos { get; set; }
        public DbSet<Inventario> Inventario { get; set; }
        public DbSet<Matricula> Matriculas { get; set; }
        public DbSet<Membresia> Membresias { get; set; }
        public DbSet<ReporteMembresia> ReporteMembresia { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}
