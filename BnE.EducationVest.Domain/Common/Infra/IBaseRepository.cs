using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BnE.EducationVest.Domain.Common.Infra
{
    public interface IBaseRepository<T> where T : EntityBase
    {
        IUnitOfWork UnitOfWork { get; }
        Task<List<T>> FindAllAsync(bool asNoTracking = false);
        Task<T> FindByIdAsync(Guid id, bool asNoTracking = false);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);

        Task DeleteAsync(T entity);

    }
}
