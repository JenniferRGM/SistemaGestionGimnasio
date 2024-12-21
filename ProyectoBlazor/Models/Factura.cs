using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoBlazor.Models;

namespace ProyectoBlazor.Modelos
{
    /// <summary>
    /// Representa una factura en el sistema de gestión del gimnasio.
    /// </summary>
    public class Factura
    {
        public int Id { get; set; }  
        public string NumeroFactura { get; set; } 
        public DateTime FechaEmision { get; set; }  
        public DateTime FechaVencimiento { get; set; }  
        public decimal Total { get; set; }  
        public int MatriculaId { get; set; }  
        public List<FacturaItem> FacturaItems { get; set; } 
        public DateTime CreatedAt { get; set; }  
        public DateTime UpdatedAt { get; set; }  

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Factura"/>.
        /// </summary>
        // Constructor por defecto
        public Factura()
        {
            FacturaItems = new List<FacturaItem>();
        }
    }
}
