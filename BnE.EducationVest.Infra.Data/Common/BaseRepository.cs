using BnE.EducationVest.Domain.Common;
using BnE.EducationVest.Domain.Common.Infra;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BnE.EducationVest.Infra.Data.Common
{
    public class BaseRepository<T> : IBaseRepository<T> where T : EntityBase
    {
        internal readonly EducationVestContext _context;
        internal readonly DbSet<T> _db;
        public BaseRepository(EducationVestContext context)
        {
            _context = context;
            _db = context.Set<T>();
        }
        public IUnitOfWork UnitOfWork => _context;

        public virtual async Task AddAsync(T entity)
        {
            _db.Add(entity);
            await _context.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(T entity)
        {
            _db.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public virtual Task<List<T>> FindAllAsync(bool asNoTracking = false)
        {
            if (asNoTracking)
                return _db.AsNoTracking().ToListAsync();

            return _db.ToListAsync();
        }
        public async Task<T> FindByIdAsync(Guid id, bool asNoTracking = false)
        {
            if (asNoTracking)
                return await _db.AsNoTracking()
                                .FirstOrDefaultAsync(x => x.Id == id);

            return await _db.Include("Periods").FirstOrDefaultAsync(x => x.Id == id);
        }

        public virtual async Task UpdateAsync(T entity)
        {
            var a = _db.Update(entity);
            await _context.Commit();
        }
    }
}
