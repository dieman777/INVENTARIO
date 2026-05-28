using INVENTARIO.Server.Models;
using Microsoft.EntityFrameworkCore;


namespace INVENTARIO.Server
{
    public class InventarioDBContext :DbContext
    {
        public InventarioDBContext(DbContextOptions<InventarioDBContext> options) : base(options)
        {

        }

        public DbSet<Productos> Productos { get; set; }
        public DbSet<Usuarios> Usuarios{ get; set; }
    }
}
