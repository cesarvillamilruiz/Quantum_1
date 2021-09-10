using System;
using System.Collections.Generic;

namespace LogicLayer.DTO
{
    public class FacturaDTO
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public long Identificacion { get; set; }
        public decimal TotalVenta { get; set; }
        public decimal Subtotal { get; set; }
        public string Direccion { get; set; }
        public int Telefono { get; set; }
        public DateTime FechaEntrega { get; set; }
        public List<DetalleFacturaDTO> DetalleFacturaDTO { get; set; }
    }
}
