namespace ProyectoBlazor.Models
{
    public class FacturaItem
    {
        public int Id { get; set; }  // Identificador único del ítem
        public int FacturaId { get; set; }  // Relación con la factura
        public string Descripcion { get; set; }  // Descripción del ítem
        public int Cantidad { get; set; }  // Cantidad del ítem
        public decimal PrecioUnitario { get; set; }  // Precio unitario
        public decimal TotalItem { get; set; }  // Total del ítem (Cantidad * PrecioUnitario)
        public DateTime CreatedAt { get; set; }  // Fecha de creación
        public DateTime UpdatedAt { get; set; }  // Fecha de actualización
    }
}
