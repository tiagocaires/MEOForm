using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meo.Model
{
    public class Answer : AModelBase
    {
        public Question Question { get; set; }
        public int QuestionId { get; set; }
        public Form Form { get; set; }
        public int FormId { get; set; }
        public string AnswerDescription { get; set; }
    }
}
