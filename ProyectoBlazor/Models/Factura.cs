using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoBlazor.Models;

namespace SistemaGestionGimnasio.Modelos
{
    public class Factura
    {
        public int Id { get; set; }  // Identificador único de la factura
        public string NumeroFactura { get; set; }  // Número único de la factura
        public DateTime FechaEmision { get; set; }  // Fecha de emisión de la factura
        public DateTime FechaVencimiento { get; set; }  // Fecha de vencimiento de la factura
        public decimal Total { get; set; }  // Monto total de la factura
        public int MatriculaId { get; set; }  // Relación con la matrícula
        public List<FacturaItem> FacturaItems { get; set; }  // Lista de ítems asociados a la factura
        public DateTime CreatedAt { get; set; }  // Fecha de creación
        public DateTime UpdatedAt { get; set; }  // Fecha de actualización

        // Constructor por defecto
        public Factura()
        {
            FacturaItems = new List<FacturaItem>();
        }
    }
}
