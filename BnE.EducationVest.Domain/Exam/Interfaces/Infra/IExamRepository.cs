using BnE.EducationVest.Domain.Common.Infra;
using BnE.EducationVest.Domain.Users.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BnE.EducationVest.Domain.Exam.Interfaces.Infra
{
    public interface IExamRepository : IBaseRepository<Entities.Exam>
    {
        Task<List<Entities.Exam>> GetAvailableExams();
        Task<Entities.Exam> GetByIdWithAllIncludes(Guid id);
        Task AddExamPeriodsAsync(Entities.Exam exam);
    }
}
