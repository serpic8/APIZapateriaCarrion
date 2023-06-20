namespace ZapateriaAPI.Models.Dto
{
    public class SalesCreateDto
    {
        
        public DateTime FechaVenta { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Total { get; set; }
    }
}
