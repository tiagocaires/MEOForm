using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meo.Service.RequestModel
{
    public class AnswerModelRequest
    {
        public int QuestionId { get; set; }
        public string AnswerDescription { get; set; }
    }
}
