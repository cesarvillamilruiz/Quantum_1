using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Data.Entities
{
    public class DetalleFactura : IEntity
    {
        [Key]
        public int Id { get; set; }        
        public Producto Producto { get; set; }
        [Required]
        public int ProductoId { get; set; }
        [Required]
        public int Cantidad { get; set; }
        [Required]
        [Column(TypeName = "DECIMAL(18, 0)")]
        [Display(Name = "Valor Unitario Sin Iva")]
        public decimal ValorUnitarioSinIva { get; set; }
        [Required]
        [Column(TypeName = "DECIMAL(18, 0)")]
        [Display(Name = "Valor Unitario Con Iva")]
        public decimal ValorUnitarioConIva { get; set; }
        [Required]
        [Column(TypeName = "DECIMAL(18, 0)")]
        [Display(Name = "Valor Total Producto")]
        public decimal ValorTotalProducto { get; set; }
        public Factura Factura { get; set; }
        [Required]
        public int FacturaId { get; set; }

    }
}
