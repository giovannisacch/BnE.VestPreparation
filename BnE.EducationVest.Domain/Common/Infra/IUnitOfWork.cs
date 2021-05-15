using System.Threading.Tasks;

namespace BnE.EducationVest.Domain.Common.Infra
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}
