using System.Threading.Tasks;

namespace BnE.EducationVest.Domain.Exam.Interfaces.InfraService
{
    public interface IExamReportService
    {
        Task ScheduleExamReport(string id);
    }
}
