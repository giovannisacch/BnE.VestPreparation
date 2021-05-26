using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BnE.EducationVest.Domain
{
    public static class ErrorConstants
    {
        public const string WRONG_PASSWORD = "WRONG_PASSWORD";
        public const string SHOULD_BE_FIRST_PASSWORD_CHANGE = "SHOULD_BE_FIRST_PASSWORD_CHANGE";
        public const string NEW_PASSWORD_REQUIRED = "NEW_PASSWORD_REQUIRED";
        public const string USER_NOT_FOUND = "USER_NOT_FOUND";
        public const string TOKEN_EXPIRED = "TOKEN_EXPIRED";
        public const string WRONG_TOKEN = "WRONG_TOKEN";
        public const string EMPTY_EXAM_PERIODS = "EMPTY_EXAM_PERIODS";
        public const string ALTERNATIVE_COUNT_SHOULD_BE_FIVE = "ALTERNATIVE_COUNT_SHOULD_BE_FIVE";
        public const string PERIOD_OPENDATE_SHOULD_BE_EARLIER_THAN_CLOSEDATE = "PERIOD_OPENDATE_SHOULD_BE_EARLIER_THAN_CLOSEDATE";
        public const string EXAM_NOT_FOUND = "EXAM_NOT_FOUND";
        public const string QUESTION_NOT_FOUND = "QUESTION_NOT_FOUND";
        public const string QUESTION_ANSWER_NOT_FOUND = "QUESTION_ANSWER_NOT_FOUND";
    }
}
