using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meo.Model.Factory
{
    public class AnswerFactory
    {
        public static Answer Create(int pFormId, string pAnswer, int pQuestionId)
        {
            return new Answer
            {
                AnswerDescription = pAnswer,
                QuestionId = pQuestionId,
                FormId = pFormId,
                Created = DateTime.UtcNow,
            };
        }
    }
}
