using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meo.Service.ViewModel
{
    public class AnswerViewModel
    {
        public QuestionViewModel Question { get; set; }
        public string AnswerDescription { get; set; }
    }
}
