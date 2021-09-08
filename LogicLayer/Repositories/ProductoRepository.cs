using DataAccess.Data.Entities;
using DataAccess.DataAccess;
using LogicLayer.Interfaces;

namespace LogicLayer.Repositories
{
    public class ProductoRepository : GenericRepository<Producto>, IProductoRepository
    {
        private readonly DataContext context;
        public ProductoRepository(DataContext context): base(context)
        {
            this.context = context;
        }
    }
}
