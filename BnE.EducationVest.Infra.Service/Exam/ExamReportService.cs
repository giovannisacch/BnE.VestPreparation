using Amazon.CloudWatchEvents;
using Amazon.CloudWatchEvents.Model;
using BnE.EducationVest.Domain.Exam.Interfaces.InfraService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BnE.EducationVest.Infra.Service.Exam
{
    public class ExamReportService : IExamReportService
    {
        private readonly IAmazonCloudWatchEvents _amazonCloudWatchEventsClient;
        public ExamReportService(IAmazonCloudWatchEvents amazonCloudWatchEventsClient)
        {
            _amazonCloudWatchEventsClient = amazonCloudWatchEventsClient;
        }

        public async Task ScheduleExamReport(string id)
        {
            var ruleName = $"updateReport{id}metrics";
            //Criar regra
            var putRuleRequest = new PutRuleRequest
            {
                Name = ruleName,
                ScheduleExpression = "cron(09 13 23 08 ? 2021)"
            };
            var ruleResponse = await _amazonCloudWatchEventsClient.PutRuleAsync(putRuleRequest);
            var putTargetRequest = new PutTargetsRequest
            {
                Rule = ruleName,
                Targets =
                {
                    new Target { Arn = "arn:aws:lambda:sa-east-1:442405506364:function:call-updateReportMetrics", Id = id, Input = "{\"name:\":\"Testeeeeee\"}"}
                }
            };
           var response = await _amazonCloudWatchEventsClient.PutTargetsAsync(putTargetRequest);
        }
    }
}
