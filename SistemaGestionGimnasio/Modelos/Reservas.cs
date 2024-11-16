using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionGimnasio.Modelos
{
    public class Reservas
    {
        public string Usuario { get; set; }
        public string ClaseReservada { get; set; }
        public DateTime FechaReserva { get; set; }

        public Reservas(string usuario, string claseReservada, DateTime fechaReserva)
        {
            Usuario = usuario;
            ClaseReservada = claseReservada;
            FechaReserva = fechaReserva;
        }
    }
}
