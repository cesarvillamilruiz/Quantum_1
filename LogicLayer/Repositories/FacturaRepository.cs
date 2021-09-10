using DataAccess.Data.Entities;
using DataAccess.DataAccess;
using LogicLayer.DTO;
using LogicLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogicLayer.Repositories
{
    public class FacturaRepository : GenericRepository<Factura>, IFacturaRepository
    {
        private readonly DataContext context;
        public FacturaRepository(DataContext context) : base(context)
        {
            this.context = context;
        }

        public async Task Add_Bill(FacturaDTO model)
        {
            Factura factura = new Factura();

            factura.Nombre = model.Nombre;
            factura.Apellido = model.Apellido;
            factura.Identificacion = model.Identificacion;
            factura.FechaVenta = DateTime.Now;
            factura.TotalVenta = model.TotalVenta;
            factura.Subtotal = model.Subtotal;
            factura.Direccion = model.Direccion;
            factura.Telefono = model.Telefono;
            factura.FechaEntrega = model.FechaEntrega;

            this.context.Database.BeginTransaction();

            try
            {
                await this.context.Factura.AddAsync(factura);
                await this.context.SaveChangesAsync();
                foreach (var item in model.DetalleFacturaDTO)
                {
                    DetalleFactura detalleFactura = new DetalleFactura();
                    detalleFactura.ProductoId = item.ProductoId;
                    detalleFactura.Cantidad = item.Cantidad;
                    detalleFactura.ValorUnitarioSinIva = (item.Cantidad * item.ValorUnitarioConIva) - ((item.Cantidad * item.ValorUnitarioConIva) * item.PorcentajeIvaaplicado);
                    detalleFactura.ValorUnitarioConIva = item.ValorUnitarioConIva;
                    detalleFactura.ValorTotalProducto = item.Cantidad * item.ValorUnitarioConIva;
                    detalleFactura.FacturaId = factura.Id;

                    await this.context.DetalleFactura.AddAsync(detalleFactura);
                    await this.context.SaveChangesAsync();

                    Producto producto = await this.context.Producto
                        .FirstOrDefaultAsync(i => i.Id == item.ProductoId);

                    producto.CantidadUnidadesInventario = producto.CantidadUnidadesInventario - item.Cantidad;
                    await this.context.SaveChangesAsync();
                }
                this.context.Database.CommitTransaction();
            }
            catch (Exception e)
            {
                this.context.Database.RollbackTransaction();
            }
        }

        public async Task<List<Factura>> GetAllBills()
        {
            List<Factura> result = new List<Factura>();
            try
            {
                result = await this.context.Factura
                    .Include(d => d.DetalleFactura)
                    .ThenInclude(p => p.Producto)
                    .OrderBy(f => f.FechaVenta)
                    .ToListAsync();
                return result;
            }
            catch (Exception e)
            {

            }
            return result;
        }

        public async Task<Factura> GetByBillDetailAsync(int id)
        {
            Factura result = new Factura();
            try
            {
                result = await this.context.Factura
                    .Where(f => f.Id == id)
                    .Include(d => d.DetalleFactura)
                    .ThenInclude(p => p.Producto)
                    .OrderBy(f => f.FechaVenta)
                    .FirstOrDefaultAsync();
                return result;
            }
            catch (Exception e)
            {

            }
            return result;
        }
    }
}
