using BnE.EducationVest.Domain.Common;
using BnE.EducationVest.Domain.Common.Infra;

namespace BnE.EducationVest.Infra.Data.Common
{
    public class BaseRepository<T> : IBaseRepository<T> where T : EntityBase
    {
        private readonly EducationVestContext _context;
        public BaseRepository(EducationVestContext context)
        {
            _context = context;
        }
        public IUnitOfWork UnitOfWork => _context;
    }
}
