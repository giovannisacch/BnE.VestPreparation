﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BnE.EducationVest.Application.Exams.ViewModels
{
    public class AvailableExamsViewModel
    {
        public List<AvailableExamViewModel> AvailableExams { get; set; }
    }
    public class AvailableExamViewModel
    {
        public Guid ExamId { get; set; }
        public string ExamName { get; set; }
        public DateTime ExpirationDate { get; set; }
        public bool WasStarted { get; set; }
        public int QuestionsCount { get; set; }
        public int? LastQuestionAnswered { get; set; }
        public bool WasFinalized { get; set; }
        public string Link { get; set; }
    }
}
