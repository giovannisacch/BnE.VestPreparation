using BnE.EducationVest.Domain.Exam.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BnE.EducationVest.Domain.Exam.ValueObjects
{
    public class PreExamVO
    {
        public EExamModel ExamModel { get; private set; }
        public EExamType ExamType { get; private set; }
        public int Number { get; private set; }
        public List<ExamPeriodVO> Periods { get; private set; }
        public List<Guid> SubjectIdList { get; private set; }
        public List<int> OrderedRightAnswerIndexList { get; private set; }
        public EExamTopic ExamTopic { get; private set; }
        public Guid? FatherExamModuleId { get; private set; }
        public string Link { get; private set; }

        public PreExamVO(EExamModel examModel, EExamType examType, int number, List<ExamPeriodVO> periods, List<Guid> subjectIdList, EExamTopic examTopic, Guid? fatherExamModuleId, 
            List<int> orderedRightAnswerIndexList, string link)
        {
            ExamModel = examModel;
            ExamType = examType;
            Number = number;
            Periods = periods;
            SubjectIdList = subjectIdList;
            ExamTopic = examTopic;
            FatherExamModuleId = fatherExamModuleId;
            OrderedRightAnswerIndexList = orderedRightAnswerIndexList;
            Link = link;
        }
    }
}
