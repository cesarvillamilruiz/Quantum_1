using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Data.Entities
{
    public class Factura : IEntity
    {

        [Key]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "VARCHAR(128)")]
        public string Nombre { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(128)")]
        public string Apellido { get; set; }

        [Required]
        public long Identificacion { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha Venta")]
        public DateTime FechaVenta { get; set; }

        [Required]
        [Column(TypeName = "DECIMAL(18, 0)")]
        [Display(Name = "Total Venta")]
        public decimal TotalVenta { get; set; }

        [Required]
        [Column(TypeName = "DECIMAL(18, 0)")]
        public decimal Subtotal { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(128)")]
        public string Direccion { get; set; }

        [Required]
        public int Telefono { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "FechaEntrega")]
        public DateTime FechaEntrega { get; set; }

        public List<DetalleFactura> DetalleFactura { get; set; }
    }
}
