using DataAccess.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.DataAccess
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options)
        {

        }
        public DbSet<Producto> Producto { get; set; }
    }
}
