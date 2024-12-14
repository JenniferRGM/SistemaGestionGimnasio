using SistemaGestionGimnasio.Modelos;

namespace ProyectoBlazor.Models
{
    public class EspacioModel
    {
        public Int32 id { get; set; }
        public Int32 claseId { get; set; }

        public String claseNombre { get; set; }

        public DateTime fecha { get; set; }

        public Int32 Cupos { get; set; }

        public ClasesModel clase { get; set; }


        public EspacioModel(int id, int claseId, DateTime fecha, String claseNombre, int cupos)
        {
            this.claseNombre = claseNombre;
            this.id = id;
            this.claseId = claseId;
            this.fecha = fecha;
            this.Cupos = cupos;
        }
    }
}

