namespace ZapateriaAPI.Models.Dto
{
    public class SalesUpdateDto
    {
        public int IDVenta { get; set; }
        
        public DateTime FechaVenta { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Total { get; set; }
    }
}
