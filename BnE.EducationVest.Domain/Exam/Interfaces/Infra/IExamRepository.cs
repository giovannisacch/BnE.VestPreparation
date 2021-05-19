using BnE.EducationVest.Domain.Common.Infra;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BnE.EducationVest.Domain.Exam.Interfaces.Infra
{
    public interface IExamRepository : IBaseRepository<Entities.Exam>
    {
        Task<List<Entities.Exam>> GetAvailableExams();
        Task<Entities.Exam> GetByIdWithAllIncludes(Guid id);
    }
}
