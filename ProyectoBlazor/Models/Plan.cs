namespace ProyectoBlazor.Models
{
    /// <summary>
    /// Representa un plan dentro del sistema.
    /// </summary>
    public class Plan
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Plan"/>.
        /// </summary>
        /// <param name="id">Identificador único del plan.</param>
        /// <param name="nombre">Nombre del plan.</param>
        public Plan(int id, string nombre)
        {
            Id = id;
            Nombre = nombre;
        }
    }
}
