using System;
using System.Collections.Generic;
using System.Text;

namespace LogicLayer.DTO
{
    public class ProductoDTO
    {
        public string Nombre { get; set; }
        public decimal ValorVentaConIva { get; set; }
        public int CantidadUnidadesInventario { get; set; }
        public decimal PorcentajeIvaaplicado { get; set; }
    }
}
