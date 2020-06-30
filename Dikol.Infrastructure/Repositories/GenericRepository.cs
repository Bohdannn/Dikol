using Dikol.Core.Entities;
using Dikol.Core.Interfaces;
using Dikol.Core.Specifications;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dikol.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly DikolDbContext _dikolDbContext;

        public GenericRepository(DikolDbContext dikolDbContext)
        {
            _dikolDbContext = dikolDbContext;
        }

        private IQueryable<T> ApplySpecification(ISpecification<T> specification)
            => SpecificationEvaluator<T>.GetQuery(_dikolDbContext.Set<T>().AsQueryable(), specification);

        public async Task<IReadOnlyList<T>> GetAllAsync() => await _dikolDbContext.Set<T>().ToListAsync();

        public async Task<IReadOnlyList<T>> GetAllAsync(ISpecification<T> specification)
            => await ApplySpecification(specification).ToListAsync();

        public async Task<T> GetByIdAsync(int id) => await _dikolDbContext.Set<T>().FindAsync(id);

        public async Task<T> GetEntityAsync(ISpecification<T> specification) 
            => await ApplySpecification(specification).SingleOrDefaultAsync();
    }
}
