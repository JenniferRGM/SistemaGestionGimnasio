namespace ProyectoBlazor.Models
{
    /// <summary>
    /// Modelo para representar los detalles de un error en la aplicación.
    /// </summary>
    public class ErrorViewModel
    {
        /// <summary>
        /// Identificador único de la solicitud donde ocurrió el error.
        /// </summary>
        public string? RequestId { get; set; }

        /// <summary>
        /// Indica si el identificador de la solicitud debe mostrarse.
        /// </summary>
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
