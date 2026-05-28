using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace INVENTARIO.Server.Repositories
{
    public class Repository<X> : IRepository<X> where X : class
    {
        //Variables
        public readonly InventarioDBContext _context;
        public DbSet<X> _dbSet;

        //Constructor
        public Repository(InventarioDBContext context)
        {
            _context = context;
            _dbSet = context.Set<X>();
        }

        //Insertar datos
        public async Task Insert(X model)
        {
            await _dbSet.AddAsync(model);
        }

        //Suprmir datos
        public void Delete(X model)
        {
            _dbSet.Remove(model);
        }

        //Obtener datos
        public async Task<IEnumerable<X>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }
        //Obtener datos por id
        public async Task<X> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }
        //Guardar cambios
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
        //Actualizar datos
        public void Update(X model)
        {
            _dbSet.Update(model);
        }

    }
}
