namespace ProyectoBlazor.Models
{
    /// <summary>
    /// Representa un ítem individual asociado a una factura en el sistema.
    /// </summary>
    public class FacturaItem
    {
        public int Id { get; set; } 
        public int FacturaId { get; set; }  
        public string Descripcion { get; set; }  
        public int Cantidad { get; set; }  
        public decimal PrecioUnitario { get; set; } 
        public decimal TotalItem { get; set; }  // Total del ítem (Cantidad * PrecioUnitario)
        public DateTime CreatedAt { get; set; } 
        public DateTime UpdatedAt { get; set; }  
    }
}
