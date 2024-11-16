using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionGimnasio.Modelos
{
    internal class Membresia
    {
        public DateTime FechaInicio { get; set; }
        public DateTime FechaVencimiento { get; set; }

        public Membresia(DateTime fechaInicio, DateTime fechaVencimiento)
        {
            FechaInicio = fechaInicio;
            FechaVencimiento = fechaVencimiento;
        }

        public int DiasRestantes()
        {
            return (FechaVencimiento - DateTime.Now).Days;
        }

        public bool EstaPorVencer()
        {
            return DiasRestantes() <= 5;
        }
    }
}
