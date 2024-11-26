using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionGimnasio.Modelos
{
    internal class Factura
    {
        public int NumeroFactura { get; set; }
        public DateTime FechaEmision { get; set; }
        public string Cliente { get; set; }
        public double Monto { get; set; }
        public string Estado { get; set; }

        public Factura(int numeroFactura, DateTime fechaEmision, string cliente, double monto, string estado)
        {
            NumeroFactura = numeroFactura;
            FechaEmision = fechaEmision;
            Cliente = cliente;
            Monto = monto;
            Estado = estado;
        }
    }
}
