using DataAccess.Data.Entities;
using LogicLayer.DTO;
using LogicLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LogicLayer.Bussiness
{
    public class FacturaService
    {
        public async Task<List<Factura>> Get_Bills(IFacturaRepository facturaRepository)
        {
            List<Factura> result = new List<Factura>();
            try
            {
                result = await facturaRepository.GetAllBills();
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public async Task<(bool, Factura)> Get_Bill_By_Id(IFacturaRepository facturaRepository, int id)
        {
            try
            {
                Factura factura = await facturaRepository.GetByBillDetailAsync(id);
                if (factura == null)
                {
                    return (false, null);
                }

                return (true, factura);
            }
            catch (Exception ex)
            {
                return (false, null);
            }
        }
        public async Task<bool> Add_Bill(IFacturaRepository facturaRepository, FacturaDTO model)
        {
            try
            {
                await facturaRepository.Add_Bill(model);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
