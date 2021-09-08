using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Data.Entities
{
    public partial class Producto: IEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "VARCHAR(128)")]
        public string Nombre { get; set; }
        [Required]
        [Column(TypeName = "DECIMAL(18, 0)")]
        public decimal ValorVentaConIva { get; set; }
        [Required]
        public int CantidadUnidadesInventario { get; set; }
        [Required]
        [Column(TypeName = "DECIMAL(3, 2)")]
        public decimal PorcentajeIvaaplicado { get; set; }
    }
}
