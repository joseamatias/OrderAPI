using OrderAPI.Domain.Models;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace OrderAPI.Infrastructure
{
    public interface IRepository<T> where T : Entity, IAggregateRoot
    {
        IQueryable<T> GetQueryable();
        Task<T> GetByIdAsync(int id);
        Task<T> AddAsync(T entity);
        T Update(T entity);
        T Delete(T entity);
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
