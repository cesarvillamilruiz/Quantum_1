using DataAccess.Data.Entities;

namespace LogicLayer.DTO
{
    public class DetalleFacturaDTO
    {
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        public decimal ValorUnitarioConIva { get; set; }
        public decimal PorcentajeIvaaplicado { get; set; }
        public decimal ValorTotalProducto { get; set; }
    }
}
