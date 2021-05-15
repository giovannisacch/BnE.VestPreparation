using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BnE.EducationVest.Domain.Common.Infra
{
    public interface IBaseRepository<T> where T : EntityBase
    {
        IUnitOfWork UnitOfWork { get; }

    }
}
