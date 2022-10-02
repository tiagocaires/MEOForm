using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meo.Service.ViewModel
{
    public class FormViewModel
    {
        public CampaignViewModel Campaign { get; set; }
        public PersonViewModel Person { get; set; }
        public List<AnswerViewModel> Answers { get; set; } = new List<AnswerViewModel>();
    }
}
