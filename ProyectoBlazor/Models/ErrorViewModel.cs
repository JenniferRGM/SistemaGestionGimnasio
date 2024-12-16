namespace ProyectoBlazor.Models
{
    /// <summary>
    /// Modelo para representar los detalles de un error en la aplicación.
    /// </summary>
    public class ErrorViewModel
    {
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
