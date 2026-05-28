namespace INVENTARIO.Server.Repositories
{
    public interface IRepository<X> where X : class
    {
        Task<IEnumerable<X>> GetAllAsync();
        Task<X> GetByIdAsync(int id);
        Task Insert(X model);
        void Update(X model);
        void Delete(X model);
        Task SaveChangesAsync();
    }
}
