using DataAccess.Data.Entities;
using LogicLayer.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LogicLayer.Interfaces
{
    public interface IFacturaRepository : IGenericRepository<Factura>
    {
        Task Add_Bill(FacturaDTO model);
        Task<List<Factura>> GetAllBills();
        Task<Factura> GetByBillDetailAsync(int id);
    }
}
