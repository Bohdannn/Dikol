using Dikol.Core.Entities;
using Dikol.Core.Specifications;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dikol.Core.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync(int id);
        Task<T> GetEntityAsync(ISpecification<T> specification);
        Task<int> CountAsync();

        Task<IReadOnlyList<T>> GetAllAsync();
        Task<IReadOnlyList<T>> GetAllAsync(ISpecification<T> specification);
        Task<int> CountAsync(ISpecification<T> specification);
    }
}
