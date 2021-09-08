using DataAccess.Data.Entities;
using LogicLayer.DTO;
using LogicLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogicLayer.Bussiness
{
    public class ProductService
    {        
        public async Task<List<Producto>> Get_Products(IProductoRepository productoRepository)
        {
            List<Producto> result = new List<Producto>();
            try
            {
                result = await productoRepository.GetAll().ToListAsync();
            }
            catch (Exception ex)
            {

            }            
            return result;
        }
        public async Task<(bool, ProductoDTO)> Get_Product_By_Id(IProductoRepository productoRepository, int id)
        {
            try
            {
                Producto productos = await productoRepository.GetByIdAsync(id);
                if (productos == null)
                {
                    return (false, null);
                }

                ProductoDTO result = new ProductoDTO
                {
                    Nombre = productos.Nombre,
                    ValorVentaConIva = productos.ValorVentaConIva,
                    CantidadUnidadesInventario = productos.CantidadUnidadesInventario,
                    PorcentajeIvaaplicado = productos.PorcentajeIvaaplicado
                };
                return (true, result);
            }
            catch (Exception ex)
            {
                return (false, null);
            }
        }

        public async Task<bool> Add_Product(IProductoRepository productoRepository, ProductoDTO model)
        {
            try
            {
                await productoRepository.CreateAsync(new Producto 
                {
                    Nombre = model.Nombre,
                    ValorVentaConIva = model.ValorVentaConIva,
                    CantidadUnidadesInventario = model.CantidadUnidadesInventario,
                    PorcentajeIvaaplicado = model.PorcentajeIvaaplicado
                });

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> Update_Product(IProductoRepository productoRepository, ProductoDTO model, int id)
        {
            try
            {
                Producto Product = await productoRepository.GetByIdAsync(id);
                if (Product != null)
                {
                    Product.Nombre = model.Nombre;
                    Product.ValorVentaConIva = model.ValorVentaConIva;
                    Product.CantidadUnidadesInventario = model.CantidadUnidadesInventario;
                    Product.PorcentajeIvaaplicado = model.PorcentajeIvaaplicado;

                    await productoRepository.UpdateAsync(Product);

                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> Update_Inventory(IProductoRepository productoRepository, int id, int value)
        {
            try
            {
                Producto Product = await productoRepository.GetByIdAsync(id);
                if (Product != null)
                {
                    Product.CantidadUnidadesInventario = value;

                    await productoRepository.UpdateAsync(Product);

                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> Delete_Product(IProductoRepository productoRepository, int id)
        {
            try
            {
                Producto Product = await productoRepository.GetByIdAsync(id);
                if (Product != null)
                {
                    await productoRepository.DeleteAsync(Product);

                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
